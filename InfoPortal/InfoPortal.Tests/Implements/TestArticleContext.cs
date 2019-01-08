namespace InfoPortal.DAL.Implements.Tests
{
	using System;
	using System.Linq;
	using Common;
	using InfoPortal.BL.Implements;
	using Moq;
	using Interfaces;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass()]
	public class ArticleContextArticleContext
	{
		[TestMethod()]
		public void GetArticleTest()
		{
			ArticleContext articles = new ArticleContext();

			var article = articles.GetArticle(1);
			var noart = articles.GetArticle(12332);

			Assert.AreEqual(article.ArticleId, 1);
			Assert.AreEqual(article.Language, "Eng");
			Assert.AreEqual(article.User.Name, "Boris");
			Assert.AreEqual(article.CategoryId, 3);
			Assert.AreEqual(article.Caption, "Google finally cleans up its Esta ads after eight years");
			Assert.AreEqual(article.Date.ToString("yy-MM-dd"), "18-11-11");
			Assert.AreEqual(article.Video, @"https://www.youtube.com/embed/YuOBzWF0Aws");
			Assert.AreEqual(article.Image,
				@"https://ichef.bbci.co.uk/news/660/cpsprodpb/8C8E/production/_103928953_est1.png");
			Assert.IsNotNull(article.Text);

			Assert.IsNull(noart);
		}

		[TestMethod()]
		public void GetArticlesForMainPageTest()
		{
			ArticleContext articles = new ArticleContext();

			var forMainPage = articles.GetArticlesForMainPage(3, null, 2);
			var artsForWorls = articles.GetArticlesForMainPage(4, "world");

			Assert.IsTrue(forMainPage.Count == 3);
			Assert.AreEqual(forMainPage[0].ArticleId, 10);
			Assert.AreEqual(forMainPage[1].ArticleId, 7);
			Assert.AreEqual(forMainPage[2].ArticleId, 9);
			Assert.IsTrue(artsForWorls.Count == 2);
			Assert.AreEqual(artsForWorls[0].ArticleId, 26);
			Assert.AreEqual(artsForWorls[1].ArticleId, 8);
		}

		[TestMethod()]
		public void GetSearchByNamesOfArticlesTest()
		{
			ArticleContext articles = new ArticleContext();

			var arts = articles.GetSearchByNamesOfArticles("A", 2, 2);
			var artsNoCaption = articles.GetSearchByNamesOfArticles("12dwdd213sd", 2, 4);

			Assert.IsTrue(arts.Count == 1);
			Assert.AreEqual(arts[0].ArticleId, 1);
			Assert.IsTrue(artsNoCaption.Count == 0);
		}

		[TestMethod()]
		public void GetSearchByDateTest()
		{
			ArticleContext articles = new ArticleContext();

			var arts = articles.GetSearchByDate("2018/12/30", 2);
			var noArt = articles.GetSearchByDate("2020/12/12", 4, 1);

			Assert.IsTrue(arts.Count == 1);
			Assert.AreEqual(arts[0].ArticleId, 31);
			Assert.IsTrue(noArt.Count == 0);
		}

		[TestMethod()]
		public void GetSearchByTagNameTest()
		{
			ArticleContext articles = new ArticleContext();

			var arts = articles.GetSearchByTagName("World", 2, 1);
			var artsNoTag = articles.GetSearchByNamesOfArticles("12dwdd213sd", 2, 4);

			Assert.IsTrue(arts.Count == 2);
			Assert.AreEqual(arts[0].ArticleId, 26);
			Assert.AreEqual(arts[1].ArticleId, 2);
			Assert.IsTrue(artsNoTag.Count == 0);
		}

		[TestMethod()]
		public void GetArticlesOfUserTest()
		{
			ArticleContext articles = new ArticleContext();

			var arts = articles.GetArticlesOfUser("Boris", 3, 2);
			var artsNoName = articles.GetArticlesOfUser("csdasdsd", 2, 4);

			Assert.IsTrue(arts.Count == 3);
			Assert.AreEqual(arts[0].ArticleId, 7);
			Assert.AreEqual(arts[1].ArticleId, 9);
			Assert.AreEqual(arts[2].ArticleId, 8);

			Assert.IsTrue(artsNoName.Count == 0);
		}

		[TestMethod()]
		public void GetRandomArticlesTest()
		{
			ArticleContext articles = new ArticleContext();

			var arts = articles.GetRandomArticles(1);
			var artsNoArts = articles.GetRandomArticles(1234);

			Assert.IsTrue(arts.Count == 5);
			Assert.IsFalse(arts.Select(a => a.ArticleId).Contains(1));

			Assert.IsTrue(artsNoArts.Count == 5);
		}

		[TestMethod()]
		public void GetCountArtilesTest()
		{
			ArticleContext articles = new ArticleContext();

			var arts = articles.GetCountArticles(null);
			var artsWithCategory = articles.GetCountArticles("World");
			var artWithNoCategory = articles.GetCountArticles("dad");

			Assert.IsTrue(arts == 9);
			Assert.IsTrue(artsWithCategory == 2);
			Assert.IsTrue(artWithNoCategory == 0);
		}

		[TestMethod()]
		public void GetCountArticlesSearchResultTest()
		{
			ArticleContext articles = new ArticleContext();

			var countArtsCaption = articles.GetCountArticlesSearchResult(1, "Трамп");
			var countArtsTag = articles.GetCountArticlesSearchResult(2, "World");
			var countArtsDate = articles.GetCountArticlesSearchResult(3, "2018-12-17");

			Assert.AreEqual(countArtsCaption, 1);
			Assert.AreEqual(countArtsTag, 3);
			Assert.AreEqual(countArtsDate, 1);
		}

		[TestMethod()]
		public void GetCountArticlesOfUserTest()
		{
			ArticleContext articles = new ArticleContext();

			var countBoris = articles.GetCountArticlesOfUser("Boris");
			var countNoAuthor = articles.GetCountArticlesOfUser("asdweqqwe2");

			Assert.IsTrue(countBoris != 0);
			Assert.IsTrue(countNoAuthor == 0);
		}

		[TestMethod()]
		public void GetArticleIdByCaptionTest()
		{
			ArticleContext articles = new ArticleContext();

			var articleId = articles.GetArticleIdByCaption("Google finally cleans up its Esta ads after eight years");
			var nocaption = articles.GetArticleIdByCaption("Google findasdasdadsadght years");

			Assert.IsTrue(articleId == 1);
			Assert.IsTrue(nocaption == 0);
		}

		[TestMethod()]
		public void InsertNewArticleTest()
		{
			ArticleContext articles = new ArticleContext();
			Article test = new Article
			{
				Caption = "TestCaption2",
				Text = "Test text",
				Date = DateTime.Now,
				Language = "Eng",
				Video = "testlinkVideo",
				Image = "testlinkImage",
				CategoryId = 1,
				User = new User
				{
					Name = "Boris"
				}
			};
			int countArticles = articles.GetCountArticles(null);

			articles.InsertNewArticle(test);
			int afterInsert = articles.GetCountArticles(null);

			Assert.AreNotEqual(countArticles, afterInsert);
			Assert.IsTrue((countArticles + 1) == afterInsert);
		}

		[TestMethod()]
		public void UpdateArticleTest()
		{
			ArticleContext articles = new ArticleContext();
			Article test = new Article
			{
				ArticleId = 33,
				Caption = "TestCaption2Update",
				Text = "Test text text test test",
				Date = DateTime.Now,
				Language = "Eng",
				Video = "testlinkVideo",
				Image = "testlinkImage",
				CategoryId = 1,
				User = new User
				{
					Name = "Boris"
				}
			};
			string oldName = articles.GetArticle(33).Caption;

			articles.UpdateArticle(test);
			string newName = articles.GetArticle(33).Caption;

			Assert.AreNotEqual(oldName, newName);
		}

		[TestMethod()]
		public void DeleteArticleTest()
		{
			ArticleContext articles = new ArticleContext();
			int countArticles = articles.GetCountArticles(null);

			articles.DeleteArticle(33);
			int countafteDelete = articles.GetCountArticles(null);

			Assert.AreNotEqual(countArticles, countafteDelete);
			Assert.IsNull(articles.GetArticle(33));
		}
	}
}