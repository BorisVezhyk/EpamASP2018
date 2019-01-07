namespace InfoPortal.WebUI.Models
{
	using System.Collections.Generic;
	using Common;

	public class ResultSearchArticlesViewModel
	{
		public IEnumerable<Article> Articles { get; set; }

		public PageInfo PageInfo { get; set; }

		
		public string SearchQuery { get; set; }

		public int SelectSearch { get; set; }
	}
}