namespace Common
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class Role
	{
		[Required] public int RoleId { get; set; }

		public string Name { get; set; }

		//public ICollection<User> Users { get; set; }

		//public Role()
		//{
		//	Users = new List<User>();
		//}
	}
}