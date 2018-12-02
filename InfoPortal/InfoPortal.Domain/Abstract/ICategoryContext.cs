using System.Collections.Generic;
using Common;

namespace InfoPortal.Domain.Abstract
{
	public interface ICategoryContext
	{
		List<Category> Categories { get; set; }
	}
}
