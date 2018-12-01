using System.Linq;
using System.Web.Mvc;
using Common;
using InfoPortal.BL.Abstract;


namespace InfoPortal.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
	    private readonly IArticlesRepository _repository;

	    public ArticleController(IArticlesRepository articlesRepository)
	    {
			
		    _repository = articlesRepository;
	    }


        public ActionResult Article(int? id)
        {

			if (id!=null)
	        {
				Article art = _repository.Articles.FirstOrDefault(a => a.ArticleID == id);

		        return View(art);

			}

	        return HttpNotFound();
        }
    }
}