using System.Data.Entity;

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