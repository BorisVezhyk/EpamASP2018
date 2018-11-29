using System;
using System.Linq;
using System.Net.Http;
using InfoPortal.Domain;
using NUnit.Framework;
using InfoPortal.Domain.Abstract;
using InfoPortal.Domain.Concrete;
using InfoPortal.WebUI.HtmlHelpers;
using InfoPortal.WebUI.Models;


namespace Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		//[Test]
		//public void Can_Generate_Page_Links()
		//{
		//	HtmlHelper myHelper = null;

		//	PageInfo pageInfo = new PageInfo
		//	{
		//		CurrentPage = 3,
		//		TotalItems = 23,
		//		ItemsPerPage = 6
		//	};

		//	Func<int, string> pageUrlDelegate = i => "Page" + i;

		//	MvcHtmlString result = myHelper.PageLinks(pageInfo, pageUrlDelegate);

		//	Assert.AreEqual(result.ToString(),@"a href=""Page1"")>1</a>"
		//		+@"<a class=""selected"" href=""Page3"">2</a>"
		//		+@"<a href=""Page3"">3</a>"
		//		+ @"<a href=""Page4"">4</a>");
		//}


	}
}