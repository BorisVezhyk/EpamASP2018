using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPortal.Domain.Abstract
{
	public interface ITagsRepository
	{
		IEnumerable<Tag> Tags { get; }
		void SaveTag(Tag tag);
	}
}
