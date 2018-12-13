namespace InfoPortal.BL.Implements
{
using Common;
using Interfaces;
using DAL.Interfaces;

	public class UserRepository : IUserRepository
	{
		private readonly IUserContext userContext;
		
		public UserRepository(IUserContext userContext)
		{
			this.userContext = userContext;
		}

		public int CheckUserExist(string userEmail, string userName)
		{
			return userContext.CheckUserExist(userEmail, userName);
		}

		public void RegisterUser(User user)
		{
			userContext.SaveNewUser(user);
		}

		public User GetUserByLogin(string userName, string userPassword)
		{
			return userContext.GetUserByLogin(userName, userPassword);
		}

		public string[] GetRolesForUser(string userName)
		{
			return userContext.GetRolesForUser(userName);
		}
	}
}