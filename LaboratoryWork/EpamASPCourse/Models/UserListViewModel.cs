using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamASPCourse.Models
{
	public class UserListViewModel
	{
		public IEnumerable<User> Users { get; set; }
		public PagingInfo PagingInfo { get; set; }
		public string NameUser { get; set; }
	}
}