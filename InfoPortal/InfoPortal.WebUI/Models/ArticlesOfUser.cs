namespace InfoPortal.WebUI.Models
{
	using Common;
	using System.Collections.Generic;

	public class ArticlesOfUser
	{
		public IEnumerable<Article> Articles { get; set; }

		public PageInfo PageInfo { get; set; }

		public string CurrentUserName { get; set; }
	}
}