using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace InfoPortal.WebUI.Models
{
	public class SearchAttributes
	{
		[Required]
		public string SearchQuery { get; set; }

		public int Select { get; set; }

		public IEnumerable<SelectListItem> SelectList { get; set; }
	}
}