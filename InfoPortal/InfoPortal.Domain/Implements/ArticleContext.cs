using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Common;
using InfoPortal.DAL.Interfaces;

namespace InfoPortal.DAL.Implements
{
	public class ArticleContext : DbContext, IArticleContext
	{
		public ArticleContext()
		{
			SqlConnection = new SqlConnection(ConnectionString);
		}

		public List<Article> GetArticlesForMainPage(int maxArticlesInPage, string category, int page = 1)
		{
			List<Article> articles = new List<Article>();

			using (SqlConnection = new SqlConnection(ConnectionString))
			{
				string sqlCommand = "exec sp_GetArticles @page,@maxArticlesInPage,@category";
				SqlConnection.Open();
				SqlCommand cmd = new SqlCommand(sqlCommand, SqlConnection);
				cmd.Parameters.AddWithValue("@page", page);
				cmd.Parameters.AddWithValue("@maxArticlesInPage", maxArticlesInPage);
				cmd.Parameters.AddWithValue("@category", category ?? (object) DBNull.Value);

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						articles.Add(new Article
						{
							ArticleId = (int) reader["ArticleID"],
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

			//foreach (var art in articles)
			//{
			//	art.Tags = GetTagsByArticleID(art.ArticleID);
			//}

			return articles;
		}

		private List<Tag> GetTagsByArticleId(int articleId)
		{
			List<Tag> tags = new List<Tag>();

			using (SqlConnection = new SqlConnection(ConnectionString))
			{
				string sqlCommand = "exec sp_GetTagsByArticleID @articleID";

				SqlCommand cmd = new SqlCommand(sqlCommand, SqlConnection);
				cmd.Parameters.AddWithValue("@articleID", articleId);
				SqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						tags.Add(new Tag
						{
							TagId = (int) reader["TagID"],
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

			using (SqlConnection = new SqlConnection(ConnectionString))
			{
				string sqlCommmand = "exec sp_get_count_articles_by_category @category";

				SqlCommand cmd = new SqlCommand(sqlCommmand, SqlConnection);
				cmd.Parameters.AddWithValue("@category", category ?? (object) DBNull.Value);
				try
				{
					SqlConnection.Open();
					var count = cmd.ExecuteScalar();
					if (count != null)
					{
						result = (int) count;
					}
				}
				catch (Exception e)
				{
					logger.Error(e.Message);
				}
			}

			return result;
		}

		public Article GetArticle(int articleId)
		{
			Article article = null;

			using (SqlConnection = new SqlConnection(ConnectionString))
			{
				string sqlCommand = "exec sp_get_article_by_articleID @articleID";

				SqlCommand cmd = new SqlCommand(sqlCommand, SqlConnection);
				cmd.Parameters.AddWithValue("@articleID", articleId);
				SqlConnection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						article = new Article
						{
							ArticleId = (int) reader["ArticleID"],
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
				article.Tags = GetTagsByArticleId(articleId);
				return article;
			}

			return null;
		}

		public List<Article> GetSearchByNamesOfArticles(string searchQuery, int pageSize, int page = 1)
		{
			List<Article> result = new List<Article>();
			using (SqlConnection = new SqlConnection(ConnectionString))
			{
				string sqlCommand = "exec sp_get_search_result_by_name_article @page, @pageSize, @searchQuery";

				SqlCommand cmd = new SqlCommand(sqlCommand, SqlConnection);
				cmd.Parameters.AddWithValue("@page", page);
				cmd.Parameters.AddWithValue("@pageSize", pageSize);
				cmd.Parameters.AddWithValue("@searchQuery", searchQuery);
				SqlConnection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(new Article
						{
							ArticleId = (int) reader["ArticleID"],
							Caption = (string) reader["Caption"],
							Text = (string) reader["Text"],
							Date = (DateTime) reader["Date"],
							Language = reader["Language"] as string,
							Video = reader["Video"] as string,
							Image = reader["Image"] as string,
							User = new User
							{
								Name = (string) reader["Name"],
							}
						});
					}
				}
			}

			return result;
		}

		public List<Article> GetSearchByDate(string searchQuery, int pageSize, int page = 1)
		{
			List<Article> result = new List<Article>();

			using (SqlConnection = new SqlConnection(ConnectionString))
			{
				string sqlCommand = "exec sp_get_search_result_by_date @page, @pageSize, @date";
				SqlCommand cmd = new SqlCommand(sqlCommand, SqlConnection);
				cmd.Parameters.AddWithValue("@page", page);
				cmd.Parameters.AddWithValue("@pageSize", pageSize);
				cmd.Parameters.AddWithValue("@date", searchQuery);
				SqlConnection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(new Article
						{
							ArticleId = (int) reader["ArticleID"],
							Caption = (string) reader["Caption"],
							Text = (string) reader["Text"],
							Date = (DateTime) reader["Date"],
							Language = reader["Language"] as string,
							Video = reader["Video"] as string,
							Image = reader["Image"] as string,
							User = new User
							{
								Name = (string) reader["Name"],
							}
						});
					}
				}
			}

			return result;
		}

		public List<Article> GetSearchByTagName(string searchQuery, int pageSize, int page = 1)
		{
			List<Article> result = new List<Article>();
			using (SqlConnection = new SqlConnection(ConnectionString))
			{
				string sqlCommand = "exec sp_get_search_result_by_tagname @page, @pageSize, @tagName";

				SqlCommand cmd = new SqlCommand(sqlCommand, SqlConnection);
				cmd.Parameters.AddWithValue("@page", page);
				cmd.Parameters.AddWithValue("@pageSize", pageSize);
				cmd.Parameters.AddWithValue("@tagName", searchQuery);
				SqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(new Article
						{
							ArticleId = (int) reader["ArticleID"],
							Caption = (string) reader["Caption"],
							Text = (string) reader["Text"],
							Date = (DateTime) reader["Date"],
							Language = reader["Language"] as string,
							Video = reader["Video"] as string,
							Image = reader["Image"] as string,
							User = new User
							{
								Name = (string) reader["Name"],
							}
						});
					}
				}
			}

			return result;
		}

		public int GetCountArticlesSearchResult(int selectSearch, string searchQuery)
		{
			int result = 0;
			using (SqlConnection = new SqlConnection(ConnectionString))
			{
				string sqlCommand = "exec sp_get_count_result_search @select, @query";
				SqlCommand cmd = new SqlCommand(sqlCommand, SqlConnection);
				cmd.Parameters.AddWithValue("@select", selectSearch);
				cmd.Parameters.AddWithValue("@query", searchQuery);
				try
				{
					SqlConnection.Open();
					result = (int) cmd.ExecuteScalar();
				}
				catch (Exception e)
				{
					logger.Error(e.Message);
				}
			}

			return result;
		}

		public void InsertNewArticle(Article article)
		{
			using (SqlConnection)
			{
				string sqlCommand = "INSERT INTO ByNamesOrArticles (Caption,Text,ByDate,Language,Video,Image,UserID) " +
				                    "VALUES(@Caption,@Text,@Date,@Language,@Video,@Image,@UserID)";

				SqlCommand cmd = new SqlCommand(sqlCommand, SqlConnection);
				cmd.Parameters.AddWithValue("@Caption", article.Caption);
				cmd.Parameters.AddWithValue("@Text", article.Text);
				cmd.Parameters.AddWithValue("@Date", article.Date);
				cmd.Parameters.AddWithValue("@Language", article.Language);
				cmd.Parameters.AddWithValue("@Video", article.Video);
				cmd.Parameters.AddWithValue("@Image", article.Image);
				cmd.Parameters.AddWithValue("@UserID", article.UserId);
				try
				{
					SqlConnection.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					logger.Error(e.Message);
				}
			}
		}

		public void UpdateArticle(Article article)
		{
			using (SqlConnection)
			{
				string sqlCommand = "UPDATE ByNamesOrArticles SET " +
				                    "Caption=@Caption," +
				                    "Text=@Text," +
				                    "Date=@Date," +
				                    "Language=@Language," +
				                    "Video=@Video," +
				                    "Image=@Image";

				SqlCommand cmd = new SqlCommand(sqlCommand, SqlConnection);
				cmd.Parameters.AddWithValue("@Caption", article.Caption);
				cmd.Parameters.AddWithValue("@Text", article.Text);
				cmd.Parameters.AddWithValue("@Date", article.Date);
				cmd.Parameters.AddWithValue("@Language", article.Language);
				cmd.Parameters.AddWithValue("@Video", article.Video);
				cmd.Parameters.AddWithValue("@Image", article.Image);

				try
				{
					SqlConnection.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					logger.Error(e.Message);
				}
			}
		}

		public void DeleteArticle(int articleId)
		{
			using (SqlConnection)
			{
				string sqlCommand = "DELETE FROM ByNamesOrArticles " +
				                    "WHERE ArticleID=@id";

				SqlCommand cmd = new SqlCommand(sqlCommand, SqlConnection);
				cmd.Parameters.AddWithValue("@id", articleId);

				try
				{
					SqlConnection.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					logger.Error(e.Message);
				}
			}
		}
	}
}