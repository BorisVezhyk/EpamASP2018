namespace InfoPortal.DAL.Interfaces
{
	using System.Collections.Generic;

	public interface ITagsContext
	{
		List<string> GetPopularTags(int maxTags);

		List<string> GetAllTags();
	}
}