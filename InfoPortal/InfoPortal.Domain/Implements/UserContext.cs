namespace InfoPortal.DAL.Implements
{
	using Common;
	using Interfaces;
	using System;
	using System.Data;
	using System.Linq;
	using System.Collections.Generic;
	using System.Data.SqlClient;

	public class UserContext : DbContext, IUserContext
	{
		private User GetUserFromRecord(IDataRecord record)
		{
			return new User
			{
				Name = (string) record["Name"],
				Email = (string) record["E-mail"],
				Password = (string) record["Password"],
				UserId = (int) record["UserId"]
			};
		}

		private List<Role> GetRolesByUserId(int userId)
		{
			List<Role> result = new List<Role>();
			try
			{
				string command = "exec sp_get_roles_by_userid @userId=@0";

				var records = base.ExecuteQuery(command, userId);

				foreach (var record in records)
				{
					result.Add(
						new Role
						{
							RoleId = (int) record["RoleId"],
							Name = (string) record["Name"]
						});
				}
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
			}

			return result;
		}

		public List<User> GetUsersForAdmin(int page)
		{
			List<User> result = new List<User>();

			try
			{
				string sqlCommand = "exec sp_get_users_for_admin @page=@0";
				var records = base.ExecuteQuery(sqlCommand, page);

				foreach (var record in records)
				{
					result.Add(this.GetUserFromRecord(record));
				}

				foreach (var user in result)
				{
					user.Roles = this.GetRolesByUserId(user.UserId);
				}
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
			}

			return result;
		}

		public User GetUserByName(string userName)
		{
			User result = null;

			try
			{
				string sqlCommand = "exec sp_get_user_by_name @userName=@0";
				var records = base.ExecuteQuery(sqlCommand, userName);

				result = this.GetUserFromRecord(records.FirstOrDefault());
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
			}

			return result;
		}

		public User GetUserById(int userId)
		{
			User result = null;

			try
			{
				string sqlCommand = "exec sp_get_user_by_id @userId=@0";
				var records = base.ExecuteQuery(sqlCommand, userId);

				result = this.GetUserFromRecord(records.FirstOrDefault());
				result.Roles = this.GetRolesByUserId(userId);
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
			}

			return result;
		}

		public User GetUserByLogin(string userName, string userPassword)
		{
			User result = null;

			try
			{
				string sqlCommand = "exec sp_get_user_by_login @userName=@0, @userPassword=@1";
				var records = base.ExecuteQuery(sqlCommand, userName, userPassword);

				result = this.GetUserFromRecord(records.FirstOrDefault());
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
			}

			return result;
		}

		public string[] GetRolesForUser(string userName)
		{
			List<string> roles = new List<string>();
			string sqlCommand = "exec sp_get_roles_for_user @userName=@0";

			var records = base.ExecuteQuery(sqlCommand, userName);

			roles.AddRange(records.Select(rec => (string) rec["Name"]));
			return roles.ToArray();
		}

		public int CheckUserExist(string userEmail, string userName)
		{
			string sqlCommand = "exec sp_check_user_exist @userEmail = @0, @userName = @1";
			object result = base.ExecScalar(sqlCommand, userEmail, userName);
			if (result != null)
			{
				return (int) result;
			}

			return -1;
		}

		public int GetCountAllUsers()
		{
			string sqlCommand = "exec sp_get_count_all_users";
			object result = base.ExecScalar(sqlCommand);
			if (result!=null)
			{
				return (int) result;
			}

			return 0;
		}

		public void SaveNewUser(User newUser)
		{
			SqlTransaction transaction = null;
			string sqlCommand = "exec sp_save_new_user @name,@email,@password";
			using (base.SqlConnection = new SqlConnection(base.ConnectionString))
			{
				try
				{
					this.SqlConnection.Open();
					transaction = this.SqlConnection.BeginTransaction();

					using (SqlCommand cmd = new SqlCommand(sqlCommand, base.SqlConnection, transaction))
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
					base.logger.Error(e.Message);
					transaction.Rollback();
				}
			}
		}

		public void DeleteUserById(int userId)
		{
			string sqlCommand = "exec sp_delete_user_by_id @userId";
			using (base.SqlConnection = new SqlConnection(base.ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand(sqlCommand, base.SqlConnection))
				{
					cmd.Parameters.AddWithValue("@userId", userId);
					base.SqlConnection.Open();
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
	}
}