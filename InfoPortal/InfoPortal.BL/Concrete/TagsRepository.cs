using System;
using System.Collections.Generic;
using Common;
using InfoPortal.BL.Abstract;
using InfoPortal.DAL.Abstract;
using InfoPortal.DAL.Concrete;

namespace InfoPortal.BL.Concrete
{
	public class TagsRepository : ITagsRepository
	{
		private ITagsContext _context;

		public TagsRepository(ITagsContext context)
		{
			_context = context;
		}

		public IEnumerable<Tag> Tags
		{
			get { return _context.Tags; }
		}

		public void SaveTag(Tag tag)
		{
			throw new NotImplementedException();
		}
	}
}
