using System;
using System.Collections.Generic;
using System.Linq;
using InfoPortal.Domain;
using InfoPortal.Domain.Abstract;
using InfoPortal.Domain.Concrete;
using Moq;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class ContextTests
	{
		[Test]
		public void SaveArticle()
		{
			ArticleContext context=new ArticleContext();
			context.Articles.Add(new Article {ArticleID = 1, Caption = "12", Text = "qwe", UserID = 1});
			context.Articles.Add(new Article {ArticleID = 2, Caption = "1212", Text = "qwew", UserID = 1});
			context.Articles.Add(new Article {ArticleID = 3, Caption = "11232", Text = "qwqe", UserID = 1});

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
			
			ArticleRepository res=new ArticleRepository();

			res.SaveArticle(article);
			
			Assert.IsTrue(res.Articles.Count()==4);
			
		}

	}
}