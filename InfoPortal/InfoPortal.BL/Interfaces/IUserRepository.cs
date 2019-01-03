namespace InfoPortal.BL.Interfaces
{
	using System.Collections.Generic;
	using Common;

	public interface IUserRepository
	{
		void RegisterUser(User user);

		int CheckUserExist(string userEmail, string userName);

		User GetUserByLogin(string userName, string userPassword);

		string[] GetRolesForUser(string userName);

		List<User> GetUsersForAdmin(int page);

		User GetUserById(int userId);

		void DeleteUserById(int userId);

		void UpdateUser(User user);

		int GetCountAllUsers();

		User GetUserByName(string userName);
	}
}