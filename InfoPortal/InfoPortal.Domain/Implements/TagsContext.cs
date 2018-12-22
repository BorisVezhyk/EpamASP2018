namespace InfoPortal.DAL.Implements
{
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using Interfaces;

	public class TagsContext : DbContext, ITagsContext
	{
		public List<string> GetPopularTags(int maxTags)
		{
			List<string> result = new List<string>();
			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "exec sp_get_popular_tags @maxTags";

				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@maxTags", maxTags);

				this.SqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add((string) reader["TagName"]);
					}
				}
			}

			return result;
		}

		public List<string> GetAllTags()
		{
			List<string> result = new List<string>();

			string sqlCommand = "exec sp_get_all_tags";

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				this.SqlConnection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add((string) reader["TagName"]);
					}
				}
			}

			return result;
		}
	}
}