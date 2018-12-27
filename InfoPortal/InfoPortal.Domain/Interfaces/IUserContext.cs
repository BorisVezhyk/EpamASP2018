namespace InfoPortal.DAL.Interfaces
{
	using Common;
	using System.Collections.Generic;

	public interface IUserContext
	{
		int CheckUserExist(string userEmail, string userName);

		void SaveNewUser(User newUser);

		User GetUserByLogin(string userName, string userPassword);

		string[] GetRolesForUser(string userName);

		List<User> GetUsersForAdmin(int page);

		User GetUserById(int userId);

		void DeleteUserById(int userId);

		void UpdateUser(User user);

		int GetCountAllUsers();
	}
}