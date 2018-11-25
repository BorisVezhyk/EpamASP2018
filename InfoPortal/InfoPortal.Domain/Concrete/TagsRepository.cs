using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoPortal.Domain.Abstract;

namespace InfoPortal.Domain.Concrete
{
	public class TagsRepository : ITagsRepository
	{
		public IEnumerable<Tag> Tags
		{
			get { return _context.Tags; }
		}

		TagsContext _context=new TagsContext();


		public void SaveTag(Tag tag)
		{
			throw new NotImplementedException();
		}
	}
}
