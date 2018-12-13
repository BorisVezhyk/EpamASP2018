using System.Collections.Generic;
using Common;

namespace InfoPortal.DAL.Interfaces
{
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
	}
}
