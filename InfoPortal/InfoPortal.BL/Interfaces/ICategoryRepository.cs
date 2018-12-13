using System.Collections.Generic;
using Common;

namespace InfoPortal.BL.Interfaces
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> Categories { get; }
	}
}
