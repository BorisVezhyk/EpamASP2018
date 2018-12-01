using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common
{
	public class Tag
	{

		[Required]
		public int TagID { get; set; }

		[Required]
		public string TagName { get; set; }

		public ICollection<Article> Articles { get; set; }

		public Tag()
		{
			Articles=new List<Article>();
		}

	}
}
