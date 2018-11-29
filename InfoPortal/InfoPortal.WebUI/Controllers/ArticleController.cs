using System.Linq;
using System.Web.Mvc;
using InfoPortal.Domain;
using InfoPortal.Domain.Abstract;
using InfoPortal.Domain.Concrete;

namespace InfoPortal.WebUI.Controllers
{
    public class ArticleController : Controller
    {
	    readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private readonly IArticlesRepository _repository;
        // GET: Article

	    public ArticleController(IArticlesRepository articlesRepository)
	    {
			
		    _repository = articlesRepository;
	    }


        public ActionResult Article(int? id)
        {
			logger.InfoFormat("Test log");

			if (id!=null)
	        {
				Article art = _repository.Articles.FirstOrDefault(a => a.ArticleID == id);

		        return View(art);

			}
			logger.Error("Article not found");

	        return HttpNotFound();
        }
    }
}