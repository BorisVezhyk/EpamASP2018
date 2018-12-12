using System.Collections.Generic;
using Common;

namespace InfoPortal.DAL.Abstract
{
	public interface IArticleContext
	{
		void InsertNewArticle(Article article);
		void UpdateArticle(Article article);
		void DeleteArticle(int articleID);
		List<Article> GetArticlesForMainPage(int maxArticlesInPage, string category, int page = 1);
		int GetCountArtiles(string category);
		Article GetArticle(int articleID);
		List<Article> GetSearchByNamesOfArticles(string searchQuery, int pageSize, int page = 1);
		List<Article> GetSearchByDate(string searchQuery, int pageSize, int page = 1);
		List<Article> GetSearchByTagName(string searchQuery, int pageSize, int page = 1);
		int GetCountArticlesSearchResult(int selectSearch, string searchQuery);
	}
}
