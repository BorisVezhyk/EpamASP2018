namespace InfoPortal.DAL.Interfaces
{
	using System.Collections.Generic;
	using Common;

	public interface ICategoryContext
	{
		List<Category> GetAllCategories();
	}
}