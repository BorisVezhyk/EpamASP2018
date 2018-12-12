using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Common;
using InfoPortal.DAL.Abstract;

namespace InfoPortal.DAL.Concrete
{
	public class TagsContext : ITagsContext
	{
		readonly log4net.ILog _logger =
			log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private readonly SqlConnection _sqlConnection;

		public List<Tag> Tags { get; set; }

		public TagsContext()
		{
			Tags = GetAllTags();
			string connectionString = ConfigurationManager.ConnectionStrings["DbInfoPortal"].ConnectionString;
			_sqlConnection = new SqlConnection(connectionString);
		}

		private List<Tag> GetAllTags()
		{
			List<Tag> tags = new List<Tag>();

			using (_sqlConnection)
			{
				string sqlCommand = "Select ByTags.TagID,TagName,ArticleID FROM ByTags " +
				                    "FULL OUTER JOIN ArticlesOfTag " +
				                    "ON ByTags.TagID=ArticlesOfTag.TagID";

				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);

				_sqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						Tag oldTag = tags.Find(t => t.TagID == (int) reader["TagID"]);
						if (oldTag == null)
						{
							tags.Add(new Tag
							{
								TagID = (int) reader["TagID"],
								TagName = (string) reader["TagName"],
							});
						}
						else
						{
							oldTag.Articles.Add(new Article
							{
								ArticleID = (int) reader["ArticleID"]
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
			using (_sqlConnection)
			{
				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);
				cmd.Parameters.AddWithValue("@TagName", tag.TagName);

				try
				{
					_sqlConnection.Open();
					cmd.ExecuteNonQuery();
				}
				catch (System.Exception e)
				{
					_logger.Error(e.Message);
				}
			}
		}
	}
}