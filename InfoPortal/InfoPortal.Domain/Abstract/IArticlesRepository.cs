using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPortal.Domain.Abstract
{
	public interface IArticlesRepository
	{
		IQueryable<Article> Articles { get; }
		void SaveArticle(Article article);
		void DeleteArticle(int articleId);
	}
}
