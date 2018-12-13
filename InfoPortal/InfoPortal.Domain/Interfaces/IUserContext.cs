using Common;

namespace InfoPortal.DAL.Interfaces
{
	public interface IUserContext
	{
		int CheckUserExist(string userEmail, string userName);
		void SaveNewUser(User newUser);
		User GetUserByLogin(string userName, string userPassword);
		string[] GetRolesForUser(string userName);
	}
}
