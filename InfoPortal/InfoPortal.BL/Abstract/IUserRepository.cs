using Common;

namespace InfoPortal.BL.Abstract
{
	public interface IUserRepository
	{
		void RegisterUser(User user);
		int CheckUserExist(string userEmail, string userName);
		User GetUserByLogin(string userName, string userPassword);
	}
}
