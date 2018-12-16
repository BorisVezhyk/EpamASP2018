namespace InfoPortal.BL.Implements
{
	using System.Linq;
	using System.Collections.Generic;
	using Common;
	using Interfaces;
	using InfoPortal.DAL.Interfaces;
	using System.Web.Mvc;

	public class CategoryRepository : ICategoryRepository
	{
		public IEnumerable<Category> Categories => context.GetAllCategories();

		private readonly ICategoryContext context;

		public CategoryRepository(ICategoryContext context)
		{
			this.context = context;
		}

		public IEnumerable<SelectListItem> GetCategoriesForSelectListItems()
		{
			List<SelectListItem> categories = Categories
				.OrderBy(c => c.CategoryName)
				.Select(
					c =>
						new SelectListItem
						{
							Value = c.CategoryId.ToString(),
							Text = c.CategoryName
						}).ToList();
			var helper = new SelectListItem()
			{
				Value = null,
				Text = "---select category---"
			};

			categories.Insert(0, helper);
			return new SelectList(categories, "Value", "Text");
		}
	}
}