using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPortal.Domain.Concrete
{
	class TagsContext
	{
		private SqlConnection sqlConnection = null;

		public List<Tag> Tags { get; set; }

		public TagsContext()
		{
			Tags = GetAllTags();
		}

		private void OpenConnection()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DbInfoPortal"].ConnectionString;
			sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
		}

		private void CloseConnection()
		{
			sqlConnection.Close();
		}

		private List<Tag> GetAllTags()
		{
			List<Tag> tags = new List<Tag>();

			string sqlCommand = "Select Tags.TagID,TagName,ArticleID FROM Tags " +
			                    "FULL OUTER JOIN ArticlesOfTag " +
			                    "ON Tags.TagID=ArticlesOfTag.TagID";

			OpenConnection();

			using (SqlCommand cmd=new SqlCommand(sqlCommand,sqlConnection))
			{
				SqlDataReader reader=cmd.ExecuteReader();

				while (reader.Read())
				{
					Tag oldTag = tags.Find(t => t.TagID == (int) reader["TagID"]);
					if (oldTag==null)
					{
						tags.Add(new Tag
						{
							TagID = (int)reader["TagID"],
							TagName = (string)reader["TagName"],
							//Articles = new List<Article>
							//{
							//	new Article{ArticleID =(int) reader["ArticleID"]}
							//}
							
						});
						
					}
					else
					{
						oldTag.Articles.Add(new Article
						{
							ArticleID = (int)reader["ArticleID"]
						});
					}
				}

				CloseConnection();

				return tags;
			}
		}

		public void InsertNewTag(Tag tag)
		{
			string sqlCommand = "INSERT INTO TAGS(TagName) " +
			                    "VALUES(@TagName)";
			OpenConnection();

			using (SqlCommand cmd = new SqlCommand(sqlCommand,sqlConnection))
			{
				cmd.Parameters.AddWithValue("@TagName", tag.TagName);

				cmd.ExecuteNonQuery();
			}

			CloseConnection();
		}

	}
}
