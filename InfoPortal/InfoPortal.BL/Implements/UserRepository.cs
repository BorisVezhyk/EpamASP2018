namespace InfoPortal.BL.Implements
{
	using System.Collections.Generic;
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

		public List<User> GetUsersForAdmin(int page)
		{
			return this.userContext.GetUsersForAdmin(page);
		}

		public User GetUserById(int userId)
		{
			return this.userContext.GetUserById(userId);
		}

		public void DeleteUserById(int userId)
		{
			this.userContext.DeleteUserById(userId);
		}

		public void UpdateUser(User user)
		{
			this.userContext.UpdateUser(user);
		}
	}
}