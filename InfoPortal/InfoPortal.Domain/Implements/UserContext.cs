﻿namespace InfoPortal.DAL.Implements
{
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using Common;
	using Interfaces;

	public class UserContext : DbContext, IUserContext
	{
		public int CheckUserExist(string userEmail, string userName)
		{
			int result = 1;

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "exec sp_check_user_exist @userEmail,@userName";
				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@userEmail", userEmail);
				cmd.Parameters.AddWithValue("@userName", userName);
				try
				{
					this.SqlConnection.Open();
					result = (int) cmd.ExecuteScalar();
				}
				catch (Exception e)
				{
					this.logger.Error(e.Message);
				}
			}

			return result;
		}

		public void SaveNewUser(User newUser)
		{
			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "exec sp_save_new_user @name,@email,@password";

				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@name", newUser.Name);
				cmd.Parameters.AddWithValue("@email", newUser.Email);
				cmd.Parameters.AddWithValue("@password", newUser.Password);

				try
				{
					this.SqlConnection.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					this.logger.Error(e.Message);
				}
			}
		}

		public User GetUserByLogin(string userName, string userPassword)
		{
			User result = null;

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "exec sp_get_user_by_login @userName, @userPassword";

				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@userName", userName);
				cmd.Parameters.AddWithValue("@userPassword", userPassword);
				this.SqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result = new User
						{
							Name = (string) reader["Name"],
							UserId = (int) reader["UserID"],
							Email = (string) reader["E-mail"]
						};
					}
				}
			}

			return result;
		}

		public string[] GetRolesForUser(string userName)
		{
			List<string> roles = new List<string>();

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "exec sp_get_roles_for_user @userName";

				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@userName", userName);
				this.SqlConnection.Open();

				using (SqlDataReader readear = cmd.ExecuteReader())
				{
					while (readear.Read())
					{
						roles.Add((string) readear["Name"]);
					}
				}
			}

			return roles.ToArray();
		}
	}
}