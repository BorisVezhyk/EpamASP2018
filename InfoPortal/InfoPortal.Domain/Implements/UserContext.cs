namespace InfoPortal.DAL.Implements
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
			SqlTransaction transaction = null;
			string sqlCommand = "exec sp_save_new_user @name,@email,@password";
			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				try
				{
					this.SqlConnection.Open();
					transaction = this.SqlConnection.BeginTransaction();

					using (SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection, transaction))
					{
						cmd.Parameters.AddWithValue("@name", newUser.Name);
						cmd.Parameters.AddWithValue("@email", newUser.Email);
						cmd.Parameters.AddWithValue("@password", newUser.Password);
						cmd.ExecuteNonQuery();
					}

					string commandSaveRolesOfUser = "exec sp_save_roles_for_user @userName, @roleName";
					foreach (var role in newUser.Roles)
					{
						using (SqlCommand cmd = new SqlCommand(commandSaveRolesOfUser, this.SqlConnection, transaction))
						{
							cmd.Parameters.AddWithValue("@userName", newUser.Name);
							cmd.Parameters.AddWithValue("@roleName", role.Name);
							cmd.ExecuteNonQuery();
						}
					}

					transaction.Commit();
				}
				catch (Exception e)
				{
					this.logger.Error(e.Message);
					transaction.Rollback();
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

		public List<User> GetUsersForAdmin(int page)
		{
			List<User> result = new List<User>();
			string sqlCommand = "exec sp_get_users_for_admin @page";

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@page", page);
				this.SqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(
							new User
							{
								UserId = (int) reader["UserID"],
								Name = (string) reader["Name"],
								Email = (string) reader["E-mail"],
								Password = (string) reader["Password"]
							});
					}
				}
			}

			foreach (var user in result)
			{
				user.Roles = GetRolesByUserId(user.UserId);
			}

			return result;
		}

		public User GetUserById(int userId)
		{
			User result = null;
			string sqlCommand = "exec sp_get_user_by_id @userId";

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@userId", userId);
				this.SqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result = new User
						{
							Name = (string) reader["Name"],
							Password = (string) reader["Password"],
							Email = (string) reader["E-mail"]
						};
					}
				}
			}

			result.Roles = this.GetRolesByUserId(userId);

			return result;
		}

		public void DeleteUserById(int userId)
		{
			string sqlCommand = "exec sp_delete_user_by_id @userId";
			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection))
				{
					cmd.Parameters.AddWithValue("@userId", userId);
					this.SqlConnection.Open();
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void UpdateUser(User user)
		{
			SqlTransaction transaction = null;

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				try
				{
					this.SqlConnection.Open();
					transaction = this.SqlConnection.BeginTransaction();

					string sqlCommandUpdateUser = "exec sp_update_user @userId, @userName, @userPassword, @userEmail";

					using (SqlCommand cmd = new SqlCommand(sqlCommandUpdateUser, this.SqlConnection, transaction))
					{
						cmd.Parameters.AddWithValue("@userId", user.UserId);
						cmd.Parameters.AddWithValue("@userName", user.Name);
						cmd.Parameters.AddWithValue("@userPassword", user.Password);
						cmd.Parameters.AddWithValue("@userEmail", user.Email);
						cmd.ExecuteNonQuery();
					}

					string sqlCommandDeleteRolesOfUser = "exec sp_delete_roles_of_user @userId";

					using (SqlCommand cmd = new SqlCommand(
						sqlCommandDeleteRolesOfUser,
						this.SqlConnection,
						transaction))
					{
						cmd.Parameters.AddWithValue("@userId", user.UserId);
						cmd.ExecuteNonQuery();
					}

					string commandSaveRolesOfUser = "exec sp_save_roles_for_user @userName, @roleName";
					foreach (var role in user.Roles)
					{
						using (SqlCommand cmd = new SqlCommand(commandSaveRolesOfUser, this.SqlConnection, transaction))
						{
							cmd.Parameters.AddWithValue("@userName", user.Name);
							cmd.Parameters.AddWithValue("@roleName", role.Name);
							cmd.ExecuteNonQuery();
						}
					}

					transaction.Commit();
				}
				catch (Exception e)
				{
					this.logger.Error(e.Message);
					transaction.Rollback();
				}
			}
		}

		private List<Role> GetRolesByUserId(int userId)
		{
			List<Role> result = new List<Role>();
			string command = "exec sp_get_roles_by_userid @userId";

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				SqlCommand cmd = new SqlCommand(command, this.SqlConnection);
				cmd.Parameters.AddWithValue("@userId", userId);
				this.SqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(
							new Role
							{
								RoleId = (int) reader["RoleId"],
								Name = (string) reader["Name"]
							});
					}
				}
			}

			return result;
		}

		public int GetCountAllUsers()
		{
			string sqlCommand = "exec sp_get_count_all_users";

			using (this.SqlConnection=new SqlConnection(this.ConnectionString))
			{
				using (SqlCommand cmd=new SqlCommand(sqlCommand,this.SqlConnection))
				{
					this.SqlConnection.Open();
					return (int) cmd.ExecuteScalar();
				}
			}
		}
	}
}