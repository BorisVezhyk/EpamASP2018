using System.Web.Mvc;
using InfoPortal.BL.Interfaces;

namespace InfoPortal.WebUI.Controllers
{
    public class TagsController : Controller
    {
	    private readonly ITagsRepository tags;
	    private const int MaxPopularTags = 15;

	    public TagsController(ITagsRepository tags)
	    {
		    this.tags = tags;
	    }

        // GET: Tags
        public PartialViewResult PopularTags()
        {
	        var model = this.tags.GetPopularTags(TagsController.MaxPopularTags);
            return this.PartialView(model);
        }

	    public ActionResult ShowAllTags()
	    {
		    var model = this.tags.GetAllTags();
		    return this.View(model);
	    }
    }
}