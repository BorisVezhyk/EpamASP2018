using System.Collections.Generic;
using Common;
using InfoPortal.BL.Abstract;
using InfoPortal.Domain.Abstract;

namespace InfoPortal.BL.Concrete
{
	public class CategoryRepository : ICategoryRepository
	{

		IEnumerable<Category> ICategoryRepository.Categories => _context.Categories;

		private readonly ICategoryContext _context;

		public CategoryRepository(ICategoryContext context)
		{
			_context = context;
		}
	}
}
