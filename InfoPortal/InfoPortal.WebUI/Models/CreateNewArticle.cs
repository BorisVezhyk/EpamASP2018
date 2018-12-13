using System.ComponentModel.DataAnnotations;

namespace InfoPortal.WebUI.Models
{
	public class CreateNewArticle
	{
		[Required(ErrorMessage = "This is required")]
		[Display(Name = "Caption")]
		public string Caption { get; set; }

		[Required(ErrorMessage = "This is required")]
		[Display(Name = "Text")]
		public string Text { get; set; }
		
		[Required(ErrorMessage = "This is required")]
		[Display(Name = "Labguage")]
		public string Language { get; set; }

		[Display(Name = "Video")]
		public string Video { get; set; }

		[Required(ErrorMessage = "This is required")]
		[Display(Name = "Image")]
		public string Image { get; set; }

		[RegularExpression(@"^[a-zA-Z\,]+$",ErrorMessage = "Words have to be only with comma")]
		[Display(Name = "ByTags")]
		public string Tags { get; set; }
		
		[Required(ErrorMessage = "This is required")]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

	}
}