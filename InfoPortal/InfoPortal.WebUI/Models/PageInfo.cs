﻿using System;

namespace InfoPortal.WebUI.Models
{
	public class PageInfo
	{
		public int TotalItems { get; set; }
		public int ItemsPerPage { get; set; }
		public int CurrentPage { get; set; }

		public int TotalPages
		{
			get { return (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage); }
			
		}
	}
}