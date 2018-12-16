namespace InfoPortal.BL.Interfaces
{
	using System.Collections.Generic;
	using Common;

	public interface ITagsRepository
	{
		List<Tag> GetTagsFromStrings(string[] tags);
	}
}