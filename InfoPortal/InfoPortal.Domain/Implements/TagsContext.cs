namespace InfoPortal.DAL.Implements
{
	using System.Linq;
	using System.Collections.Generic;
	using Interfaces;

	public class TagsContext : DbContext, ITagsContext
	{
		public List<string> GetPopularTags(int maxTags)
		{
			List<string> result = new List<string>();

			string sqlCommand = "exec sp_get_popular_tags @maxTags=@0";

			var records = base.ExecuteQuery(sqlCommand, maxTags);

			result.AddRange(records.Select(rec => (string) rec["TagName"]));

			return result;
		}

		public List<string> GetAllTags()
		{
			List<string> result = new List<string>();

			string sqlCommand = "exec sp_get_all_tags";

			var records = base.ExecuteQuery(sqlCommand);

			result.AddRange(records.Select(rec => (string) rec["TagName"]));

			return result;
		}
	}
}