using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common
{
	public class User
	{
		[Required]
		public int UserID { get; set; }

		[Required]
		[StringLength(20,MinimumLength = 4,ErrorMessage = "Minimum length of user's name is 4 chars")]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(20,MinimumLength = 6,ErrorMessage = "Minimum length of password is 6 chars")]
		public string Password { get; set; }

		public ICollection<Article> Articles { get; set; }
		public ICollection<Role> Roles { get; set; }

		public User()
		{
			Articles = new List<Article>();
			Roles=new List<Role>();
		}
	}
}
