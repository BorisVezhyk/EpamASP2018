

using Common;
using InfoPortal.BL.Implements;
using Moq;

namespace InfoPortal.DAL.Implements.Tests
{using InfoPortal.DAL.Interfaces;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using InfoPortal.DAL.Implements;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	[TestClass()]
	public class ArticleContextArticleContext
	{
		[TestMethod()]
		[ExpectedException(typeof(System.ArgumentOutOfRangeException))]
		public void GetArticleTest()
		{
			Mock<IArticleContext> mock=new Mock<IArticleContext>();

			mock.Setup(m => m.GetArticle(It.Is<int>(x => x > 0))).Returns<Article>(a => a);
			mock.Setup(m => m.GetArticle(It.Is<int>(x => x <= 0))).Throws<System.ArgumentOutOfRangeException>();
			var target = new ArticleRepository(mock.Object);

			var result1 = target.GetArticle(-1);
			var result2 = target.GetArticle(2);

			
		}

		[TestMethod()]
		public void GetArticlesForMainPageTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetSearchByNamesOfArticlesTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetSearchByDateTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetSearchByTagNameTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetArticlesOfUserTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetRandomArticlesTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetCountArtilesTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetCountArticlesSearchResultTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetCountArticlesOfUserTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetArticleIdByCaptionTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void InsertNewArticleTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void UpdateArticleTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void DeleteArticleTest()
		{
			Assert.Fail();
		}
	}
}