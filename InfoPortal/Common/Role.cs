namespace Common
{
	using System.ComponentModel.DataAnnotations;

	public class Role
	{
		[Required] public int RoleId { get; set; }

		public string Name { get; set; }

	}
}