using System.Collections.Generic;
using Common;
using InfoPortal.BL.Interfaces;
using InfoPortal.DAL.Interfaces;

namespace InfoPortal.BL.Implements
{
	public class CategoryRepository : ICategoryRepository
	{

		IEnumerable<Category> ICategoryRepository.Categories => context.Categories;

		private readonly ICategoryContext context;

		public CategoryRepository(ICategoryContext context)
		{
			this.context = context;
		}
	}
}
