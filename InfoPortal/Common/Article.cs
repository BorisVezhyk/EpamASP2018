namespace Common
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class Article
	{
		public int ArticleId { get; set; }

		[Required] public string Caption { get; set; }

		[Required] public string Text { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime Date { get; set; }

		public string Language { get; set; }

		public string Video { get; set; }

		public string Image { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public ICollection<Tag> Tags { get; set; }

		public Article()
		{
			Tags = new List<Tag>();
		}

		public int CategoryId { get; set; }

		public string Category { get; set; }
	}
}