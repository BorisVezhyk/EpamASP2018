﻿namespace InfoPortal.BL.Providers
{
	using Interfaces;
	using System;
	using System.Linq;
	using System.Web.Security;
	using Implements;
	using InfoPortal.DAL.Implements;

	public class CustomRole : RoleProvider
	{
		public IUserRepository UserRepository { get; set; }

		public CustomRole()
		{
			this.UserRepository = new UserRepository(new UserContext());
		}

		public override bool IsUserInRole(string username, string roleName)
		{
			var rolesUser = this.UserRepository.GetRolesForUser(username); // dont use var for uncknown return type
			return rolesUser.Any() && rolesUser.Contains(roleName);
		}

		public override string[] GetRolesForUser(string username)
		{
			string[] roles = this.UserRepository.GetRolesForUser(username);
			return roles;
		}

		public override void CreateRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new NotImplementedException();
		}

		public override bool RoleExists(string roleName)
		{
			throw new NotImplementedException();
		}

		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override string[] GetUsersInRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override string[] GetAllRoles()
		{
			throw new NotImplementedException();
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new NotImplementedException();
		}

		public override string ApplicationName { get; set; }
	}
}