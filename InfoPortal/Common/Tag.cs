namespace Common
{
	using System.ComponentModel.DataAnnotations;

	public class Tag
	{
		[Required] public int TagId { get; set; }

		[Required] public string TagName { get; set; }

	}
}