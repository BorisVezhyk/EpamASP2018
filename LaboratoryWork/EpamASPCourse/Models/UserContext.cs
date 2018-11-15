using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EpamASPCourse.Models;

namespace EpamASPCourse.Models
{
	public class UserContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public UserContext():base("UserContext")
		{
			
		}
	}
}