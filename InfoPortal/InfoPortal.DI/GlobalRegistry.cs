using InfoPortal.BL.Abstract;
using InfoPortal.BL.Concrete;
using InfoPortal.DAL.Abstract;
using InfoPortal.DAL.Concrete;
using InfoPortal.Domain.Abstract;
using InfoPortal.Domain.Concrete;
using StructureMap.Configuration.DSL;

namespace InfoPortal.DI
{
    public class GlobalRegistry : Registry
    {
	    public GlobalRegistry()
	    {
			For<IArticleContext>().Use<ArticleContext>();
		    For<ITagsContext>().Use<TagsContext>();
		    For<ICategoryContext>().Use<CategoryContext>();
		    For<ICategoryRepository>().Use<CategoryRepository>();
	    }

    }
}
