using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Common;
using InfoPortal.DAL.Abstract;
using InfoPortal.Domain.Concrete;

namespace InfoPortal.DAL.Concrete
{
	public class ArticleContext : DBContext, IArticleContext
	{
		public ArticleContext()
		{
			_sqlConnection = new SqlConnection(_connectionString);
		}

		public List<Article> GetArticlesForMainPage(int maxArticlesInPage, string category, int page = 1)
		{
			List<Article> articles = new List<Article>();

			using (_sqlConnection = new SqlConnection(_connectionString))
			{
				string sqlCommand = "exec sp_GetArticles @page,@maxArticlesInPage,@category";
				_sqlConnection.Open();
				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);
				cmd.Parameters.AddWithValue("@page", page);
				cmd.Parameters.AddWithValue("@maxArticlesInPage", maxArticlesInPage);
				cmd.Parameters.AddWithValue("@category", category ?? (object) DBNull.Value);

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						articles.Add(new Article
						{
							ArticleID = (int) reader["ArticleID"],
							Caption = (string) reader["Caption"],
							Text = (string) reader["Text"],
							Date = (DateTime) reader["Date"],
							Language = reader["Language"] as string,
							Video = reader["Video"] as string,
							Image = reader["Image"] as string,
							User = new User
							{
								Name = (string) reader["Name"],
							},
							Category = (string) reader["CategoryName"]
						});
					}
				}
			}

			foreach (var art in articles)
			{
				art.Tags = GetTagsByArticleID(art.ArticleID);
			}

			return articles;
		}

		private List<Tag> GetTagsByArticleID(int articleID)
		{
			List<Tag> tags = new List<Tag>();

			using (_sqlConnection = new SqlConnection(_connectionString))
			{
				string sqlCommand = "exec sp_GetTagsByArticleID @articleID";

				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);
				cmd.Parameters.AddWithValue("@articleID", articleID);
				_sqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						tags.Add(new Tag
						{
							TagID = (int) reader["TagID"],
							TagName = (string) reader["TagName"]
						});
					}
				}
			}

			return tags;
		}

		public int GetCountArtiles(string category)
		{
			int result = 0;

			using (_sqlConnection = new SqlConnection(_connectionString))
			{
				string sqlCommmand = "exec sp_get_count_articles_by_category @category";

				SqlCommand cmd = new SqlCommand(sqlCommmand, _sqlConnection);
				cmd.Parameters.AddWithValue("@category", category ?? (object) DBNull.Value);
				try
				{
					_sqlConnection.Open();
					var count = cmd.ExecuteScalar();
					if (count != null)
					{
						result = (int) count;
					}
				}
				catch (Exception e)
				{
					_logger.Error(e.Message);
				}
			}

			return result;
		}

		public Article GetArticle(int articleID)
		{
			Article article = null;

			using (_sqlConnection = new SqlConnection(_connectionString))
			{
				string sqlCommand = "exec sp_get_article_by_articleID @articleID";

				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);
				cmd.Parameters.AddWithValue("@articleID", articleID);
				_sqlConnection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						article = new Article
						{
							ArticleID = (int) reader["ArticleID"],
							Caption = (string) reader["Caption"],
							Text = (string) reader["Text"],
							Date = (DateTime) reader["Date"],
							Language = reader["Language"] as string,
							Video = reader["Video"] as string,
							Image = reader["Image"] as string,
							User = new User
							{
								Name = (string) reader["Name"],
							},
							Category = (string) reader["CategoryName"]
						};
					}
				}
			}

			if (article != null)
			{
				article.Tags = GetTagsByArticleID(articleID);
				return article;
			}

			return null;
		}

		public void InsertNewArticle(Article article)
		{
			using (_sqlConnection)
			{
				string sqlCommand = "INSERT INTO Articles (Caption,Text,Date,Language,Video,Image,UserID) " +
				                    "VALUES(@Caption,@Text,@Date,@Language,@Video,@Image,@UserID)";

				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);
				cmd.Parameters.AddWithValue("@Caption", article.Caption);
				cmd.Parameters.AddWithValue("@Text", article.Text);
				cmd.Parameters.AddWithValue("@Date", article.Date);
				cmd.Parameters.AddWithValue("@Language", article.Language);
				cmd.Parameters.AddWithValue("@Video", article.Video);
				cmd.Parameters.AddWithValue("@Image", article.Image);
				cmd.Parameters.AddWithValue("@UserID", article.UserID);
				try
				{
					_sqlConnection.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					_logger.Error(e.Message);
				}
			}
		}

		public void UpdateArticle(Article article)
		{
			using (_sqlConnection)
			{
				string sqlCommand = "UPDATE Articles SET " +
				                    "Caption=@Caption," +
				                    "Text=@Text," +
				                    "Date=@Date," +
				                    "Language=@Language," +
				                    "Video=@Video," +
				                    "Image=@Image";

				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);
				cmd.Parameters.AddWithValue("@Caption", article.Caption);
				cmd.Parameters.AddWithValue("@Text", article.Text);
				cmd.Parameters.AddWithValue("@Date", article.Date);
				cmd.Parameters.AddWithValue("@Language", article.Language);
				cmd.Parameters.AddWithValue("@Video", article.Video);
				cmd.Parameters.AddWithValue("@Image", article.Image);

				try
				{
					_sqlConnection.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					_logger.Error(e.Message);
				}
			}
		}

		public void DeleteArticle(int articleId)
		{
			using (_sqlConnection)
			{
				string sqlCommand = "DELETE FROM Articles " +
				                    "WHERE ArticleID=@id";

				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);
				cmd.Parameters.AddWithValue("@id", articleId);

				try
				{
					_sqlConnection.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					_logger.Error(e.Message);
				}
			}
		}
	}
}