using System;
using System.Collections.Generic;
using Common;
using InfoPortal.BL.Interfaces;
using InfoPortal.DAL.Interfaces;

namespace InfoPortal.BL.Implements
{
	public class TagsRepository : ITagsRepository
	{
		private readonly ITagsContext context;

		public TagsRepository(ITagsContext context)
		{
			this.context = context;
		}

		public IEnumerable<Tag> Tags
		{
			get { return context.Tags; }
		}

		public void SaveTag(Tag tag)
		{
			throw new NotImplementedException();
		}
	}
}
