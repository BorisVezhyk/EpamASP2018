using System;
using System.Data.SqlClient;
using Common;
using InfoPortal.Domain.Abstract;

namespace InfoPortal.Domain.Concrete
{
	public class UserContext : DBContext, IUserContext
	{
		public int CheckUserExist(string userEmail, string userName)
		{
			int result = 1;

			using (_sqlConnection = new SqlConnection(_connectionString))
			{
				string sqlCommand = "exec sp_check_user_exist @userEmail,@userName";
				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);
				cmd.Parameters.AddWithValue("@userEmail", userEmail);
				cmd.Parameters.AddWithValue("@userName", userName);
				try
				{
					_sqlConnection.Open();
					result = (int) cmd.ExecuteScalar();
				}
				catch (Exception e)
				{
					_logger.Error(e.Message);
				}
			}

			return result;
		}

		public void SaveNewUser(User newUser)
		{
			using (_sqlConnection = new SqlConnection(_connectionString))
			{
				string sqlCommand = "exec sp_save_new_user @name,@email,@password";

				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);
				cmd.Parameters.AddWithValue("@name", newUser.Name);
				cmd.Parameters.AddWithValue("@email", newUser.Email);
				cmd.Parameters.AddWithValue("@password", newUser.Password);

				try
				{
					_sqlConnection.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					_logger.Error(e.Message);
				}
			}
		}

		public User GetUserByLogin(string userName, string userPassword)
		{
			User result = null;

			using (_sqlConnection = new SqlConnection(_connectionString))
			{
				string sqlCommand = "exec sp_get_user_by_login @userName, @userPassword";

				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);
				cmd.Parameters.AddWithValue("@userName", userName);
				cmd.Parameters.AddWithValue("@userPassword", userPassword);
				_sqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result = new User
						{
							Name = (string) reader["Name"],
							UserID = (int) reader["UserID"],
							Email = (string) reader["E-mail"]
						};
					}
				}
			}

			return result;
		}
	}
}