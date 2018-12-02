using System.Collections.Generic;
using Common;

namespace InfoPortal.BL.Abstract
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> Categories { get; }
	}
}
