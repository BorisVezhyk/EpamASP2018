using System.ComponentModel.DataAnnotations;

namespace EpamASPCourse.Models
{
	public class User
	{
		public int UserId { get; set; }

		[Required]
		public string Name { get; set; }

		public string MiddleName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage = "Pls enter true email")]
		public string Email { get; set; }

		[Required]
		[StringLength(20,MinimumLength = 6, ErrorMessage = "Your password has to contain minimum 6 length")]
		[RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z]).{6,}$", ErrorMessage = "Your password has to contain one digit or one case")]
		public string Password { get; set; }

		[Required]
		[Compare("Password",ErrorMessage = "PrePassword is not equels the password")]
		public string PrePassword { get; set; }

		[Required]
		[Range(18,99, ErrorMessage = "Not available. User can have age range 18-99")]
		public int Age { get; set; }

		[Required]
		//[RegularExpression(@"^(\+\()(\d{1,3}\)-)(\d{2}-)(\d{3}-)(\d{2}-)(\d{2})$",ErrorMessage = "You enter phone. Example: +(nnn)-nn-nnn-nn-nn")]
		public int Phone { get; set; }

		[Required]
		[StringLength(100,MinimumLength = 20,ErrorMessage = "Need minimum 20 letters")]
		public string Address { get; set; }
	}
}