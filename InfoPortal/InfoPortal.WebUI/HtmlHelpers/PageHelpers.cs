using System;
using System.Text;
using System.Web.Mvc;
using InfoPortal.WebUI.Models;

namespace InfoPortal.WebUI.HtmlHelpers
{
	public static class PageHelpers
	{
		public static MvcHtmlString PageLinks(
			this HtmlHelper html,
			PageInfo pageInfo,
			Func<int, string> pageUrl,
			object htmlAttributes = null)
		{
			StringBuilder result = new StringBuilder();

			for (int i = 1; i <= pageInfo.TotalPages; i++)
			{
				TagBuilder tag=new TagBuilder("a");
				tag.MergeAttribute("href", pageUrl(i));
				tag.InnerHtml = i.ToString();
				if (i==pageInfo.CurrentPage)
				{
					tag.AddCssClass("btn selected btn-light disabled");
				}
				if (htmlAttributes != null)
				{
					var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
					tag.MergeAttributes(attributes);
				}

				result.Append(tag);
			}
			return MvcHtmlString.Create(result.ToString());
		}


		public static MvcHtmlString PageLinksBootstrap(
			this HtmlHelper html,
			PageInfo pageInfo,
			Func<int, string> pageUrl,
			object htmlAttributes = null)
		{
			StringBuilder result=new StringBuilder();
			TagBuilder ul=new TagBuilder("ul");
			ul.AddCssClass("pagination");
			for (int i = 1; i <= pageInfo.TotalPages; i++)
			{
				TagBuilder li=new TagBuilder("li");

				if (i==pageInfo.CurrentPage)
				{
					li.AddCssClass("page-item active disabled");
				}
				else
				{
					li.AddCssClass("page-item");
				}
				TagBuilder a = new TagBuilder("a");
				a.AddCssClass("page-link");
				a.MergeAttribute("href",pageUrl(i));
				a.InnerHtml = i.ToString();
				li.InnerHtml = a.ToString();
				ul.InnerHtml += li.ToString();

			}

			result.Append(ul.ToString());


			return MvcHtmlString.Create(result.ToString());
		}
	}
}