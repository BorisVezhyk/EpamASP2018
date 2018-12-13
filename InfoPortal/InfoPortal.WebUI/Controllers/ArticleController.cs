using System.Linq;
using System.Web.Mvc;
using Common;
using InfoPortal.BL.Interfaces;
using InfoPortal.WebUI.Models;


namespace InfoPortal.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
	    private readonly IArticlesRepository articlesRepository;
	    private readonly ICategoryRepository categoryRepository;

	    public ArticleController(IArticlesRepository articlesArticlesRepository,ICategoryRepository categoryRepository)
	    {
		    this.categoryRepository = categoryRepository;
		    articlesRepository = articlesArticlesRepository;
	    }

        public ActionResult Article(int id)
        {
	        Article article = articlesRepository.GetArticle(id);

	        if (article!=null)
	        {
		        return View(article);
	        }
	        return HttpNotFound();
        }


		[HttpGet]
		[Authorize(Roles = "Author")]
	    public ActionResult CreateNewArticle()
		{
			ViewBag.SelectCategory = categoryRepository.Categories;
		    return View();
	    }

	    [HttpPost]
	    public ActionResult CreateNewArticle(CreateNewArticle newArticle)
	    {
		    if (ModelState.IsValid)
		    {
				//need to change!!
			    Article preArticle = new Article
			    {
				    Caption = newArticle.Caption,
				    Text = newArticle.Text,
				    Image = newArticle.Image,
				    Video = newArticle.Video,
				    Language = newArticle.Language,
				    CategoryId = newArticle.CategoryId,
				    ArticleId = 123,
				    User = new User {Name = "Boris"},
				    UserId = 1
			    };
			    return RedirectToAction("Article");
			}

		    return View();
	    }


    }
}