using System.Collections.Generic;
using Common;

namespace InfoPortal.DAL.Interfaces
{
	public interface ICategoryContext
	{
		List<Category> Categories { get; set; }
	}
}
