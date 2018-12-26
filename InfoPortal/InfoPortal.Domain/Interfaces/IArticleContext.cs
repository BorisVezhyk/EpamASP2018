namespace InfoPortal.DAL.Interfaces
{
	using System.Collections.Generic;
	using Common;

	public interface IArticleContext
	{
		void InsertNewArticle(Article article);

		void UpdateArticle(Article article);

		void DeleteArticle(int articleId);

		List<Article> GetArticlesForMainPage(int maxArticlesInPage, string category, int page = 1);

		int GetCountArtiles(string category);

		Article GetArticle(int articleId);

		List<Article> GetSearchByNamesOfArticles(string searchQuery, int pageSize, int page = 1);

		List<Article> GetSearchByDate(string searchQuery, int pageSize, int page = 1);

		List<Article> GetSearchByTagName(string searchQuery, int pageSize, int page = 1);

		int GetCountArticlesSearchResult(int selectSearch, string searchQuery);

		int GetArticleIdByCaption(string caption);

		List<Article> GetArticlesOfUser(string userName, int maxArticlesInPage, int page = 1);

		List<Article> GetRandomArticles(int excludeId);
	}
}