namespace InfoPortal.BL.Implements
{
	using System.Collections.Generic;
	using Common;
	using Interfaces;
	using InfoPortal.DAL.Interfaces;

	public class ArticleRepository : IArticlesRepository
	{
		private readonly IArticleContext context;

		public ArticleRepository(IArticleContext context)
		{
			this.context = context;
		}

		public List<Article> GetArticlesForMainPage(int maxArticlesInPage, string category, int page = 1)
		{
			return this.context.GetArticlesForMainPage(maxArticlesInPage, category, page);
		}

		public Article GetArticle(int articleId)
		{
			return this.context.GetArticle(articleId);
		}

		public int GetCountArtiles(string category)
		{
			return this.context.GetCountArtiles(category);
		}

		public void SaveArticle(Article article)
		{
			this.context.InsertNewArticle(article);
		}

		public void DeleteArticle(int articleId)
		{
			this.context.DeleteArticle(articleId);
		}

		public List<Article> GetResultSearch(string searchQuery, int selectSearch, int pageSize, int page = 1)
		{
			List<Article> result = new List<Article>();
			if (selectSearch == (int)SearchType.ByNamesOrArticles)
			{
				result = this.context.GetSearchByNamesOfArticles(searchQuery, pageSize, page);
			}

			if (selectSearch == (int)SearchType.ByTags)
			{
				result = this.context.GetSearchByTagName(searchQuery, pageSize, page);
			}

			if (selectSearch == (int)SearchType.ByDate)
			{
				result = this.context.GetSearchByDate(searchQuery, pageSize, page);
			}

			return result;
		}

		public int GetCountArticlesSearchResult(int selectSearch, string searchQuery)
		{
			return this.context.GetCountArticlesSearchResult(selectSearch, searchQuery);
		}

		public int GetArticleIdByCaption(string caption)
		{
			return this.context.GetArticleIdByCaption(caption);
		}

		public void UpdateArticle(Article article)
		{
			this.context.UpdateArticle(article);
		}
	}
}