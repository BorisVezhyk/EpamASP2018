namespace Common
{
	using System.ComponentModel.DataAnnotations;

	public class Category
	{
		[Required] public string CategoryName { get; set; }

		[Required] public int CategoryId { get; set; }
	}
}