using InfoPortal.BL.Interfaces;
using InfoPortal.BL.Implements;
using InfoPortal.DAL.Interfaces;
using InfoPortal.DAL.Implements;
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
		    For<IUserRepository>().Use<UserRepository>();
		    For<IUserContext>().Use<UserContext>();
	    }

    }
}
