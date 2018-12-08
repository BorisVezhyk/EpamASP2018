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
	}
}
