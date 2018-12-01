using System.Collections.Generic;
using Common;

namespace InfoPortal.DAL.Abstract
{
	public interface ITagsContext
	{
		List<Tag> Tags { get; set; }
		void InsertNewTag(Tag tag);
	}
}
