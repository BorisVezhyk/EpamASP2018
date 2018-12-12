using System.Collections.Generic;
using Common;
using InfoPortal.BL.Abstract;
using InfoPortal.DAL.Abstract;

namespace InfoPortal.BL.Concrete
{
	public class ArticleRepository : IArticlesRepository
	{
		private IArticleContext _context;

		public ArticleRepository(IArticleContext context)
		{
			_context = context;
		}

		public List<Article> GetArticlesForMainPage(int maxArticlesInPage, string category, int page = 1)
		{
			return _context.GetArticlesForMainPage(maxArticlesInPage, category, page);
		}

		public Article GetArticle(int articleID)
		{
			return _context.GetArticle(articleID);
		}

		public int GetCountArtiles(string category)
		{
			return _context.GetCountArtiles(category);
		}

		public void SaveArticle(Article article)
		{
			_context.InsertNewArticle(article);
		}

		public void DeleteArticle(int articleId)
		{
			_context.DeleteArticle(articleId);
		}

		public List<Article> GetResultSearch(string searchQuery, int selectSearch, int pageSize, int page = 1)
		{
			List<Article> result = new List<Article>();
			if (selectSearch == (int) TypeSearch.ByNamesOrArticles)
			{
				result = _context.GetSearchByNamesOfArticles(searchQuery, pageSize, page);
			}

			if (selectSearch == (int) TypeSearch.ByTags)
			{
				result = _context.GetSearchByTagName(searchQuery, pageSize, page);
			}

			if (selectSearch == (int) TypeSearch.ByDate)
			{
				result = _context.GetSearchByDate(searchQuery, pageSize, page);
			}

			return result;
		}

		public int GetCountArticlesSearchResult(int selectSearch, string searchQuery)
		{
			return _context.GetCountArticlesSearchResult(selectSearch, searchQuery);
		}
	}
}