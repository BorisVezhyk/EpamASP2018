using System.Collections.Generic;
using Common;

namespace InfoPortal.DAL.Abstract
{
	public interface IArticleContext
	{
		List<Article> Articles { get; set; }
		void InsertNewArticle(Article article);
		void UpdateArticle(Article article);
		void DeleteArticle(int articleID);
	}
}
