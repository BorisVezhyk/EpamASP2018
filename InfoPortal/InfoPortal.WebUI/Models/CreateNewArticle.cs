namespace InfoPortal.WebUI.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class CreateNewArticle
	{
		[Required(ErrorMessage = "This is required")]
		[Display(Name = "Caption")]
		public string Caption { get; set; }

		[Required(ErrorMessage = "This is required")]
		[Display(Name = "Text")]
		public string Text { get; set; }

		[Required(ErrorMessage = "This is required")]
		[Display(Name = "Language")]
		public string Language { get; set; }

		[Display(Name = "Video")] public string Video { get; set; }

		[Required(ErrorMessage = "This is required")]
		[Display(Name = "Image")]
		public string Image { get; set; }

		[Required]
		[RegularExpression(@"^[a-zA-Z\,]+$", ErrorMessage = "Words have to be only with comma")]
		[Display(Name = "Tags")]
		public string Tags { get; set; }

		[Required(ErrorMessage = "This is required")]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public IEnumerable<SelectListItem> Categories { get; set; }
	}
}