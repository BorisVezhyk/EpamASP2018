using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common
{
	public class Article
    {
		//Need to add an attribute(display)
		[Required]
	    public int ArticleID { get; set; }

		[Required]
	    public string Caption { get; set; }

		[Required]
	    public string Text { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
	    public DateTime Date { get; set; }

	    public string Language { get; set; }

	    public string Video { get; set; }

	    public string Image { get; set; }

	    public int UserID { get; set; }

	    public User User { get; set; }

		public ICollection<Tag> Tags { get; set; }

	    public Article()
	    {
		    Tags=new List<Tag>();
	    }

	    public int CategoryID { get; set; }

	    public string Category { get; set; }

    }
}
