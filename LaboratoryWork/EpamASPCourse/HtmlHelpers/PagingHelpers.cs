using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EpamASPCourse.Models;

namespace EpamASPCourse.HtmlHelpers
{
	public static class PagingHelpers
	{
		public static MvcHtmlString PageLinks(
			this HtmlHelper html,
			PagingInfo pagingInfo,
			Func<int, string> pageUrl,
			object htmlAttributes=null)
			
		{
			StringBuilder result = new StringBuilder();

			for (int i = 1; i <= pagingInfo.TotalPages; i++)
			{
				TagBuilder tag=new TagBuilder("a");
				tag.MergeAttribute("href",pageUrl(i));
				tag.InnerHtml = i.ToString();
				if (i==pagingInfo.CurrentPage)
				{
					tag.AddCssClass("btn selectedPage");
					
				}
				if (htmlAttributes!=null)
				{
					var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
					tag.MergeAttributes(attributes);
				}
				result.Append(tag.ToString());
			}

			
			return MvcHtmlString.Create(result.ToString());
		}
	}
}