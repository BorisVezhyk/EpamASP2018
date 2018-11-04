using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Less14HomeWork_route_.Models
{
	public class Category
	{
		string[] categories =
		{
			"Economy",
			"Politics",
			"Sport",
			"Society"
		};

		public string[] Categories
		{
			get { return categories; }
		}

	}
}