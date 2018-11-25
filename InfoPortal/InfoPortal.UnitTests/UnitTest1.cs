using System;
using System.Linq;
using InfoPortal.Domain;
using NUnit.Framework;
using InfoPortal.Domain.Abstract;
using InfoPortal.Domain.Concrete;

namespace Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void SaveArticle()
		{
			Article article = new Article
			{
				ArticleID = 0,
				UserID = 1,
				Caption = "cap1",
				Text = "Sometext",
				Language = "ru",
				Date = new DateTime(2018, 11, 12),
				Image = "someLink",
				Video = "someLinkForVideo"
			};

			ArticleRepository res = new ArticleRepository();

			res.SaveArticle(article);

			Assert.IsTrue(res.Articles.Count() == 1);
		}


	}
}