namespace InfoPortal.WebUI.Controllers
{
	using BL.Interfaces;
	using Common;
	using Models;
	using System.Web.Mvc;
	using System;

	public class ArticleController : Controller
	{
		// GET: Article
		private readonly IArticlesRepository articlesRepository;
		private readonly ICategoryRepository categoryRepository;
		private readonly ITagsRepository tagsRepository;

		public ArticleController(
			IArticlesRepository articlesArticlesRepository,
			ICategoryRepository categoryRepository,
			ITagsRepository tags)
		{
			this.categoryRepository = categoryRepository;
			this.articlesRepository = articlesArticlesRepository;
			this.tagsRepository = tags;
		}

		public ActionResult Article(int id)
		{
			Article article = this.articlesRepository.GetArticle(id);

			if (article != null)
			{
				return View(article);
			}

			return HttpNotFound();
		}

		[HttpGet]
		[Authorize(Roles = "Author,Admin")]
		public ActionResult CreateNewArticle()
		{
			CreateNewArticle model =
				new CreateNewArticle { Categories = this.categoryRepository.GetCategoriesForSelectListItems() };
			return View(model);
		}

		[HttpPost]
		public ActionResult CreateNewArticle(CreateNewArticle newArticle,string returnUrl)
		{
			if (ModelState.IsValid)
			{
				Article preArticle = new Article
				{
					Date = DateTime.Now,
					Caption = newArticle.Caption,
					Text = newArticle.Text,
					Image = newArticle.Image,
					Video = newArticle.Video,
					Language = newArticle.Language,
					CategoryId = newArticle.CategoryId,
					User = new User { Name = User.Identity.Name },
					Tags = this.tagsRepository.GetTagsFromStrings(newArticle.Tags.Split(','))
				};
				this.articlesRepository.SaveArticle(preArticle);
				int articleId = this.articlesRepository.GetArticleIdByCaption(preArticle.Caption);

				return RedirectToAction("Article", new { id = articleId });
			}

			return View();
		}

		public ActionResult Preview(Article model)
		{
			
			//ViewBag.ReturnUrl = returnUrl;
			return this.View(model);
		}
	}
}