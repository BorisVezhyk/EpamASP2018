namespace InfoPortal.BL.Interfaces
{
	using System.Collections.Generic;
	using Common;
	using System.Web.Mvc;

	public interface ICategoryRepository
	{
		IEnumerable<Category> Categories { get; }

		IEnumerable<SelectListItem> GetCategoriesForSelectListItems();
	}
}