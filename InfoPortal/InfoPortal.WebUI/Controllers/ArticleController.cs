using System.Linq;
using System.Web.Mvc;
using InfoPortal.Domain;
using InfoPortal.Domain.Abstract;
using InfoPortal.Domain.Concrete;

namespace InfoPortal.WebUI.Controllers
{
    public class ArticleController : Controller
    {
		IArticlesRepository res =new ArticleRepository();
        // GET: Article



        public ActionResult Article(int id=0)
        {
	        Article art = res.Articles.FirstOrDefault(a => a.ArticleID == 1);
	      
	        
            return View(art);
        }
    }
}