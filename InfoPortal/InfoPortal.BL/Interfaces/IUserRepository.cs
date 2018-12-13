using Common;

namespace InfoPortal.BL.Interfaces
{
	public interface IUserRepository
	{
		void RegisterUser(User user);
		int CheckUserExist(string userEmail, string userName);
		User GetUserByLogin(string userName, string userPassword);
		string[] GetRolesForUser(string userName);
	}
}
