using System.Collections.Generic;
using Common;

namespace InfoPortal.WebUI.Models
{
	public class ResultSearchArticlesViewModel
	{
		public IEnumerable<Article> Articles { get; set; }
		public PageInfo PageInfo { get; set; }
		public string SearchQuery { get; set; }
		public int SelectSearch { get; set; }
	}
}