
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using InfoPortal.DAL.Abstract;
using InfoPortal.DAL.Concrete;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace InfoPortal.DI
{
    public class GlobalRegistry : Registry
    {
	    public GlobalRegistry()
	    {
			For<IArticleContext>().Use<ArticleContext>();
		    For<ITagsContext>().Use<TagsContext>();
	    }

    }
}
