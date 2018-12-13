using System.Collections.Generic;
using Common;
using InfoPortal.BL.Interfaces;
using InfoPortal.DAL.Interfaces;

namespace InfoPortal.BL.Implements
{
	public class ArticleRepository : IArticlesRepository
	{
		private IArticleContext context;

		public ArticleRepository(IArticleContext context)
		{
			this.context = context;
		}

		public List<Article> GetArticlesForMainPage(int maxArticlesInPage, string category, int page = 1)
		{
			return context.GetArticlesForMainPage(maxArticlesInPage, category, page);
		}

		public Article GetArticle(int articleId)
		{
			return context.GetArticle(articleId);
		}

		public int GetCountArtiles(string category)
		{
			return context.GetCountArtiles(category);
		}

		public void SaveArticle(Article article)
		{
			context.InsertNewArticle(article);
		}

		public void DeleteArticle(int articleId)
		{
			context.DeleteArticle(articleId);
		}

		public List<Article> GetResultSearch(string searchQuery, int selectSearch, int pageSize, int page = 1)
		{
			List<Article> result = new List<Article>();
			if (selectSearch == (int) TypeSearch.ByNamesOrArticles)
			{
				result = context.GetSearchByNamesOfArticles(searchQuery, pageSize, page);
			}

			if (selectSearch == (int) TypeSearch.ByTags)
			{
				result = context.GetSearchByTagName(searchQuery, pageSize, page);
			}

			if (selectSearch == (int) TypeSearch.ByDate)
			{
				result = context.GetSearchByDate(searchQuery, pageSize, page);
			}

			return result;
		}

		public int GetCountArticlesSearchResult(int selectSearch, string searchQuery)
		{
			return context.GetCountArticlesSearchResult(selectSearch, searchQuery);
		}
	}
}