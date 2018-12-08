using Common;

namespace InfoPortal.Domain.Abstract
{
	public interface IUserContext
	{
		int CheckUserExist(string userEmail, string userName);
		void SaveNewUser(User newUser);
		User GetUserByLogin(string userName, string userPassword);
	}
}
