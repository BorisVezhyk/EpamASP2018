namespace InfoPortal.WebUI.Controllers
{
	using BL.Interfaces;
	using Common;
	using Models;
	using System.Web.Mvc;
	using System;
	using System.Linq;

	public class ArticleController : Controller
	{
		// GET: Article
		private readonly IArticlesRepository articlesRepository;
		private readonly ICategoryRepository categoryRepository;
		private readonly ITagsRepository tagsRepository;
		private const int MaxManageArticlesOfUser = 20;

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

		[Authorize(Roles = "Editor,Admin")]
		public ActionResult UpdateArticle(int id)
		{
			Article changingArticle = this.articlesRepository.GetArticle(id);
			UpdateArticleModelView model = new UpdateArticleModelView
			{
				ArticleId = changingArticle.ArticleId,
				Categories = this.categoryRepository.GetCategoriesForSelectListItems(),
				CategoryId = changingArticle.CategoryId,
				Caption = changingArticle.Caption,
				Text = changingArticle.Text,
				Language = changingArticle.Language,
				Image = changingArticle.Image,
				Video = changingArticle.Video,
				Tags = string.Join(",", changingArticle.Tags.Select(t => t.TagName))
			};
			
			return this.View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Editor,Admin")]
		public ActionResult UpdateArticle(UpdateArticleModelView changingArticle)
		{
			if (ModelState.IsValid)
			{
				Article updateArticle = new Article
				{
					ArticleId = changingArticle.ArticleId,
					Caption = changingArticle.Caption,
					Text = changingArticle.Text,
					Language = changingArticle.Language,
					Video = changingArticle.Video,
					Image = changingArticle.Image,
					CategoryId = changingArticle.CategoryId,
					Tags = this.tagsRepository.GetTagsFromStrings(changingArticle.Tags.Split(','))
				};
				this.articlesRepository.UpdateArticle(updateArticle);
				return RedirectToAction("Article", new { id = changingArticle.ArticleId });
			}
			return this.View(changingArticle);
		}

		[HttpGet]
		[Authorize(Roles = "Editor,Admin")]
		public ActionResult CreateNewArticle()
		{
			CreateNewArticle model =
				new CreateNewArticle { Categories = this.categoryRepository.GetCategoriesForSelectListItems() };
			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Editor,Admin")]
		public ActionResult CreateNewArticle(CreateNewArticle newArticle)
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

		[Authorize(Roles = "Editor,Admin")]
		public ActionResult Delete(int articleId)
		{
			this.articlesRepository.DeleteArticle(articleId);
			return RedirectToAction("List", "Main");
		}

		[Authorize(Roles = "Editor,Admin")]
		public ActionResult ListOfArticles(string userName = null,int page=1)
		{
			var model2 = new ArticlesOfUser
			{
				Articles = this.articlesRepository.GetArticlesOfUser(
					userName,
					ArticleController.MaxManageArticlesOfUser,
					page),
				PageInfo = new PageInfo
				{
					ItemsPerPage = ArticleController.MaxManageArticlesOfUser,
					CurrentPage = page,
					TotalItems = this.articlesRepository.GetCountArticlesOfUser(userName)
				},
				CurrentUserName = userName
			};
			return this.View(model2);
		}
	}
}