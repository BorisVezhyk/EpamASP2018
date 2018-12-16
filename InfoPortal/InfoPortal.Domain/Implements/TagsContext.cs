namespace InfoPortal.DAL.Implements
{
	using System.Collections.Generic;
	using System.Configuration;
	using System.Data.SqlClient;
	using Common;
	using Interfaces;

	public class TagsContext : DbContext, ITagsContext
	{
		

		public List<Tag> Tags { get; set; }

		public TagsContext()
		{
			
		}

		//private List<Tag> GetAllTags()
		//{
		//	List<Tag> tags = new List<Tag>();

		//	using (this.sqlConnection)
		//	{
		//		string sqlCommand = "Select ByTags.TagID,TagName,ArticleID FROM ByTags " +
		//		                    "FULL OUTER JOIN ArticlesOfTag " +
		//		                    "ON ByTags.TagID=ArticlesOfTag.TagID";

		//		SqlCommand cmd = new SqlCommand(sqlCommand, this.sqlConnection);

		//		this.sqlConnection.Open();

		//		using (SqlDataReader reader = cmd.ExecuteReader())
		//		{
		//			while (reader.Read())
		//			{
		//				Tag oldTag = tags.Find(t => t.TagId == (int) reader["TagID"]);
		//				if (oldTag == null)
		//				{
		//					tags.Add(
		//						new Tag
		//						{
		//							TagId = (int) reader["TagID"],
		//							TagName = (string) reader["TagName"],
		//						});
		//				}
		//				else
		//				{
		//					oldTag.Articles.Add(
		//						new Article
		//						{
		//							ArticleId = (int) reader["ArticleID"]
		//						});
		//				}
		//			}
		//		}

		//		return tags;
		//	}
		//}

		//public void InsertNewTag(Tag tag)
		//{
		//	string sqlCommand = "INSERT INTO TAGS(TagName) " +
		//	                    "VALUES(@TagName)";
		//	using (this.sqlConnection)
		//	{
		//		SqlCommand cmd = new SqlCommand(sqlCommand, this.sqlConnection);
		//		cmd.Parameters.AddWithValue("@TagName", tag.TagName);

		//		try
		//		{
		//			this.sqlConnection.Open();
		//			cmd.ExecuteNonQuery();
		//		}
		//		catch (System.Exception e)
		//		{
		//			this.logger.Error(e.Message);
		//		}
		//	}
		//}
	}
}