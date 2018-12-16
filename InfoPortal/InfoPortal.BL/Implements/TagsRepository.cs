namespace InfoPortal.BL.Implements
{
	using System.Collections.Generic;
	using Common;
	using Interfaces;
	using InfoPortal.DAL.Interfaces;

	public class TagsRepository : ITagsRepository
	{
		private readonly ITagsContext context;

		public TagsRepository(ITagsContext context)
		{
			this.context = context;
		}

		public List<Tag> GetTagsFromStrings(string[] tags)
		{
			List<Tag> result = new List<Tag>();
			foreach (var tag in tags)
			{
				result.Add(new Tag
				{
					TagName = tag
				});
			}

			return result;
		}
	}
}