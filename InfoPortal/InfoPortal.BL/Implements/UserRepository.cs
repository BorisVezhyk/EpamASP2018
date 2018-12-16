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
			return this.userContext.CheckUserExist(userEmail, userName);
		}

		public void RegisterUser(User user)
		{
			this.userContext.SaveNewUser(user);
		}

		public User GetUserByLogin(string userName, string userPassword)
		{
			return this.userContext.GetUserByLogin(userName, userPassword);
		}

		public string[] GetRolesForUser(string userName)
		{
			return this.userContext.GetRolesForUser(userName);
		}
	}
}