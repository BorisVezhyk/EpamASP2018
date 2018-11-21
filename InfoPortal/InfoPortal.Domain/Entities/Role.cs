﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoPortal.Domain
{
	public class Role
	{
		[Required]
		public int RoleID { get; set; }

		public string Name { get; set; }

		public ICollection<User> Users { get; set; }

		public Role()
		{
			Users=new List<User>();
		}
	}
}
