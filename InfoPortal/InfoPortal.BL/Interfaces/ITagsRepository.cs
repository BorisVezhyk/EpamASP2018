using System.Collections.Generic;
using Common;

namespace InfoPortal.BL.Interfaces
{
	public interface ITagsRepository
	{
		IEnumerable<Tag> Tags { get; }
		void SaveTag(Tag tag);
	}
}
