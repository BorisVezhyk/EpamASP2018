namespace InfoPortal.BL.Interfaces
{
	using Common;
	using System.Collections.Generic;

	public interface ITagsRepository
	{
		List<string> GetPopularTags(int maxTags);

		List<Tag> GetTagsFromStrings(string[] tags);

		List<string> GetAllTags();
	}
}