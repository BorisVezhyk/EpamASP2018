using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Common;
using InfoPortal.BL.Interfaces;
using InfoPortal.DAL.Implements;
using InfoPortal.DAL.Interfaces;
using InfoPortal.WebUI.HtmlHelpers;
using InfoPortal.WebUI.Models;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfoPortal.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Can_Generate_Page_Links_Bootstrap()
		{
			HtmlHelper myHelper = null;

			PageInfo pageInfo = new PageInfo
			{
				CurrentPage = 2,
				TotalItems = 15,
				ItemsPerPage = 10
			};

			Func<int, string> pageUrlDelegate = i => "Page" + i;
			MvcHtmlString result = myHelper.PageLinksBootstrap(pageInfo, pageUrlDelegate);


			Assert.AreEqual(result.ToString() , "<ul class=\"pagination\"><li class=\"page-item\"><a class=\"page-link\" href=\"Page1\">1</a></li><li class=\"page-item active disabled\"><a class=\"page-link\" href=\"Page2\">2</a></li></ul>");
		}

		[TestMethod]
		public void Can_Send_Pagination_View_Model()
		{
			Mock<IArticlesRepository> mock = new Mock<IArticlesRepository>();
			mock.Setup(m => m.GetArticlesForMainPage(It.IsAny<int>(),It.IsAny<string>(),It.IsAny<int>())).Returns(new ArticleContext().GetArticlesForMainPage()
			//	new List<Article>
			//{
			//	new Article {ArticleId = 1, Caption = "A1"},
			//	new Article {ArticleId = 2, Caption = "A2"},
			//	new Article {ArticleId = 3, Caption = "A3"},
			//	new Article {ArticleId = 4, Caption = "A4"},
			//	new Article {ArticleId = 5, Caption = "A5"},
			//	new Article {ArticleId = 6, Caption = "A6"},
			//	new Article {ArticleId = 7, Caption = "A7"}

			//}
				);
			mock.Setup(m => m.GetCountArtiles(It.IsAny<string>())).Returns(23);

		}

	}
}
