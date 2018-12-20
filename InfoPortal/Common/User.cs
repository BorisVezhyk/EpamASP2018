using System.Collections.Generic;

namespace Common
{
	using System.ComponentModel.DataAnnotations;

	public class User
	{
		public int UserId { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 4, ErrorMessage = "Minimum length of user's name is 4 chars")]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(20, MinimumLength = 6, ErrorMessage = "Minimum length of password is 6 chars")]
		public string Password { get; set; }

		public ICollection<Role> Roles { get; set; }

		public User()
		{
			Roles=new List<Role>();
		}
	}
}