using System.ComponentModel.DataAnnotations;

namespace Common
{
    public class Category
    {
		[Required]
	    public string CategoryName { get; set; }

		[Required]
	    public int CategoryID { get; set; }
    }
}
