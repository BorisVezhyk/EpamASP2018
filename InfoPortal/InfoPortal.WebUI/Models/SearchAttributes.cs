namespace InfoPortal.WebUI.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class SearchAttributes
	{
		[Required]
		public string SearchQuery { get; set; }

		public int Select { get; set; }

		public IEnumerable<SelectListItem> SelectList { get; set; }
	}
}