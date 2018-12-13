using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Common;
using InfoPortal.DAL.Interfaces;

namespace InfoPortal.DAL.Implements
{
	public class TagsContext : ITagsContext
	{
		readonly log4net.ILog logger =
			log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private readonly SqlConnection sqlConnection;

		public List<Tag> Tags { get; set; }

		public TagsContext()
		{
			Tags = GetAllTags();
			string connectionString = ConfigurationManager.ConnectionStrings["DbInfoPortal"].ConnectionString;
			sqlConnection = new SqlConnection(connectionString);
		}

		private List<Tag> GetAllTags()
		{
			List<Tag> tags = new List<Tag>();

			using (sqlConnection)
			{
				string sqlCommand = "Select ByTags.TagID,TagName,ArticleID FROM ByTags " +
				                    "FULL OUTER JOIN ArticlesOfTag " +
				                    "ON ByTags.TagID=ArticlesOfTag.TagID";

				SqlCommand cmd = new SqlCommand(sqlCommand, sqlConnection);

				sqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						Tag oldTag = tags.Find(t => t.TagId == (int) reader["TagID"]);
						if (oldTag == null)
						{
							tags.Add(new Tag
							{
								TagId = (int) reader["TagID"],
								TagName = (string) reader["TagName"],
							});
						}
						else
						{
							oldTag.Articles.Add(new Article
							{
								ArticleId = (int) reader["ArticleID"]
							});
						}
					}
				}

				return tags;
			}
		}

		public void InsertNewTag(Tag tag)
		{
			string sqlCommand = "INSERT INTO TAGS(TagName) " +
			                    "VALUES(@TagName)";
			using (sqlConnection)
			{
				SqlCommand cmd = new SqlCommand(sqlCommand, sqlConnection);
				cmd.Parameters.AddWithValue("@TagName", tag.TagName);

				try
				{
					sqlConnection.Open();
					cmd.ExecuteNonQuery();
				}
				catch (System.Exception e)
				{
					logger.Error(e.Message);
				}
			}
		}
	}
}