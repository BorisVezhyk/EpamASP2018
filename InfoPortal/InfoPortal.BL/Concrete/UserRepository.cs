using Common;
using InfoPortal.BL.Abstract;
using InfoPortal.Domain.Abstract;

namespace InfoPortal.BL.Concrete
{
	public class UserRepository : IUserRepository
	{
		private readonly IUserContext _userContext;

		public UserRepository(IUserContext userContext)
		{
			_userContext = userContext;
		}

		public int CheckUserExist(string userEmail, string userName)
		{
			return _userContext.CheckUserExist(userEmail, userName);
		}

		public void RegisterUser(User user)
		{
			_userContext.SaveNewUser(user);
		}

		public User GetUserByLogin(string userName, string userPassword)
		{
			return _userContext.GetUserByLogin(userName, userPassword);
		}

		public string[] GetRolesForUser(string userName)
		{
			return _userContext.GetRolesForUser(userName);
		}
	}
}