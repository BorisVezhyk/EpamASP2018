using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfoPortal.Domain;

namespace InfoPortal.WebUI.Models
{
	public class ArticlesListViewModel
	{
		public IEnumerable<Article> Articles { get; set; }
		public PageInfo PageInfo { get; set; }

	}
}