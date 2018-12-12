﻿using System.Collections.Generic;
using Common;

namespace InfoPortal.BL.Abstract
{
	public interface IArticlesRepository
	{
		void SaveArticle(Article article);
		void DeleteArticle(int articleId);
		List<Article> GetArticlesForMainPage(int maxArticlesInPage, string category, int page = 1);
		int GetCountArtiles(string category);
		Article GetArticle(int articleID);
		List<Article> GetResultSearch(string searchQuery, int selectSearch, int pageSize, int page = 1);
		int GetCountArticlesSearchResult(int selectSearch, string searchQuery);
	}
}
