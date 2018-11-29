using System;
using System.Collections.Generic;
using System.Linq;
using InfoPortal.Domain.Abstract;

namespace InfoPortal.Domain.Concrete
{
	public class ArticleRepository : IArticlesRepository
	{
		private ArticleContext _context = new ArticleContext();

		public IEnumerable<Article> Articles
		{
			get { return _context.Articles; }
		}

		public void SaveArticle(Article article)
		{
			if (article.ArticleID==0)
			{
				_context.Articles.Add(article);
				_context.InsertNewArticle(article);
			}
			else
			{
				Article changedArticle = _context.Articles.Find(a=>a.ArticleID==article.ArticleID);
				if (changedArticle!=null)
				{
					changedArticle.Caption = article.Caption;
					changedArticle.Date = article.Date;
					changedArticle.Image = article.Image;
					changedArticle.Text = article.Text;
					changedArticle.Video = article.Video;
					changedArticle.Tags = article.Tags;
					changedArticle.Language = article.Language;
					changedArticle.UserID = article.UserID;
				}
				_context.UpdateArticle(article);
			}
		}


		public void DeleteArticle(int articleId)
		{
			_context.Articles.RemoveAll(a=>a.ArticleID==articleId);
			_context.DeleteArticle(articleId);
		}
	}
}
