using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InfoPortal.WebUI.Models
{
	public class SearchAttributes
	{
		public DateTime Date { get; set; }

		public string ArtName { get; set; }

		public string TagName { get; set; }

		public int Select { get; set; }

		public IEnumerable<SelectListItem> SelectList { get; set; }
	}
}