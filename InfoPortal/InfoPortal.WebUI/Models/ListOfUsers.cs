using System.Collections.Generic;
using Common;

namespace InfoPortal.WebUI.Models
{
	public class ListOfUsers
	{
		public IEnumerable<User> Users { get; set; }

		public PageInfo PageInfo { get; set; }

	}
}