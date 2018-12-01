using System.Collections.Generic;
using Common;

namespace InfoPortal.BL.Abstract
{
	public interface IArticlesRepository
	{
		IEnumerable<Article> Articles { get; }
		void SaveArticle(Article article);
		void DeleteArticle(int articleId);
	}
}
