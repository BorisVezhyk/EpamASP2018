namespace InfoPortal.WebUI.Models
{
	using System.Web.Mvc;

	public class UpdateArticleModelView : CreateNewArticle
	{
		[HiddenInput(DisplayValue = false)]
		public int ArticleId { get; set; }
	}
}