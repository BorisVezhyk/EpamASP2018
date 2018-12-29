namespace InfoPortal.WebUI.Models
{
	using Common;
	using System.Collections.Generic;

	public class ListOfUsers
	{
		public IEnumerable<User> Users { get; set; }

		public PageInfo PageInfo { get; set; }
		
	}
}