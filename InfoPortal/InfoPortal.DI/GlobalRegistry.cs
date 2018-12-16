namespace InfoPortal.DI
{
	using BL.Interfaces;
	using BL.Implements;
	using DAL.Interfaces;
	using DAL.Implements;
	using StructureMap.Configuration.DSL;

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