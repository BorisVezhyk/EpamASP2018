using System.Collections.Generic;
using Common;

namespace InfoPortal.WebUI.Models
{
	public class ArticlesListViewModel
	{
		public IEnumerable<Article> Articles { get; set; }
		public PageInfo PageInfo { get; set; }
		public string CurrentCategory { get; set; }
	}
}