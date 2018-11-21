using System.Collections.Generic;

namespace EpamASPCourse.Models
{
	public class UserListViewModel
	{
		public IEnumerable<User> Users { get; set; }
		public PagingInfo PagingInfo { get; set; }
		public string NameUser { get; set; }
	}
}