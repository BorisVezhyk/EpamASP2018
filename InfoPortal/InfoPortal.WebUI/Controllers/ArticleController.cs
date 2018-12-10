using System.Linq;
using System.Web.Mvc;
using Common;
using InfoPortal.BL.Abstract;
using InfoPortal.WebUI.Models;


namespace InfoPortal.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
	    private readonly IArticlesRepository _articlesRepository;
	    private readonly ICategoryRepository _categoryRepository;

	    public ArticleController(IArticlesRepository articlesArticlesRepository,ICategoryRepository categoryRepository)
	    {
		    _categoryRepository = categoryRepository;
		    _articlesRepository = articlesArticlesRepository;
	    }

        public ActionResult Article(int id)
        {
	        Article article = _articlesRepository.GetArticle(id);

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
			ViewBag.SelectCategory = _categoryRepository.Categories;
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
				    CategoryID = newArticle.CategoryID,
				    ArticleID = 123,
				    User = new User {Name = "Boris"},
				    UserID = 1
			    };
			    return RedirectToAction("Article");
			}

		    return View();
	    }


    }
}