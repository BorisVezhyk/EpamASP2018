namespace InfoPortal.DAL.Implements
{
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using Common;
	using Interfaces;

	public class ArticleContext : DbContext, IArticleContext
	{
		public List<Article> GetArticlesForMainPage(int maxArticlesInPage, string category, int page = 1)
		{
			List<Article> articles = new List<Article>();

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "exec sp_GetArticles @page,@maxArticlesInPage,@category";
				this.SqlConnection.Open();
				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@page", page);
				cmd.Parameters.AddWithValue("@maxArticlesInPage", maxArticlesInPage);
				cmd.Parameters.AddWithValue("@category", category ?? (object) DBNull.Value);

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						articles.Add(
							new Article
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

			return articles;
		}

		public int GetCountArtiles(string category)
		{
			int result = 0;

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommmand = "exec sp_get_count_articles_by_category @category";

				SqlCommand cmd = new SqlCommand(sqlCommmand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@category", category ?? (object) DBNull.Value);
				try
				{
					this.SqlConnection.Open();
					var count = cmd.ExecuteScalar();
					if (count != null)
					{
						result = (int) count;
					}
				}
				catch (Exception e)
				{
					this.logger.Error(e.Message);
				}
			}

			return result;
		}

		public Article GetArticle(int articleId)
		{
			Article article = null;

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "exec sp_get_article_by_articleID @articleID";

				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@articleID", articleId);
				this.SqlConnection.Open();
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
							Category = (string) reader["CategoryName"],
							CategoryId = (int) reader["CategoryID"]
						};
					}
				}
			}

			if (article != null)
			{
				article.Tags = this.GetTagsByArticleId(articleId);
				return article;
			}

			return null;
		}

		public List<Article> GetSearchByNamesOfArticles(string searchQuery, int pageSize, int page = 1)
		{
			List<Article> result = new List<Article>();
			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "exec sp_get_search_result_by_name_article @page, @pageSize, @searchQuery";

				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@page", page);
				cmd.Parameters.AddWithValue("@pageSize", pageSize);
				cmd.Parameters.AddWithValue("@searchQuery", searchQuery);
				this.SqlConnection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(
							new Article
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

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "exec sp_get_search_result_by_date @page, @pageSize, @date";
				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@page", page);
				cmd.Parameters.AddWithValue("@pageSize", pageSize);
				cmd.Parameters.AddWithValue("@date", searchQuery);
				this.SqlConnection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(
							new Article
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
			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "exec sp_get_search_result_by_tagname @page, @pageSize, @tagName";

				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@page", page);
				cmd.Parameters.AddWithValue("@pageSize", pageSize);
				cmd.Parameters.AddWithValue("@tagName", searchQuery);
				this.SqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(
							new Article
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
			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "exec sp_get_count_result_search @select, @query";
				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@select", selectSearch);
				cmd.Parameters.AddWithValue("@query", searchQuery);
				try
				{
					this.SqlConnection.Open();
					result = (int) cmd.ExecuteScalar();
				}
				catch (Exception e)
				{
					this.logger.Error(e.Message);
				}
			}

			return result;
		}

		public void InsertNewArticle(Article article)
		{
			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommandWriteArticle =
					"exec sp_save_article @caption , @text, @date, @lang, @video,	@image,	@userName,	@categoryid";

				string sqlCommandWriteTags = "exec sp_save_tags_for_atricle @articleIdenty, @tagname";

				SqlTransaction transaction = null;
				try
				{
					this.SqlConnection.Open();
					transaction = this.SqlConnection.BeginTransaction();

					SqlCommand cmd = new SqlCommand(sqlCommandWriteArticle, this.SqlConnection, transaction);
					cmd.Parameters.AddWithValue("@caption", article.Caption);
					cmd.Parameters.AddWithValue("@text", article.Text);
					cmd.Parameters.AddWithValue("@date", article.Date);
					cmd.Parameters.AddWithValue("@lang", article.Language);
					cmd.Parameters.AddWithValue("@video", article.Video ?? (object) DBNull.Value);
					cmd.Parameters.AddWithValue("@image", article.Image);
					cmd.Parameters.AddWithValue("@userName", article.User.Name);
					cmd.Parameters.AddWithValue("@categoryid", article.CategoryId);

					int articleId = (int) cmd.ExecuteScalar();

					foreach (var tag in article.Tags)
					{
						using (SqlCommand command = new SqlCommand(
							sqlCommandWriteTags,
							this.SqlConnection,
							transaction))
						{
							command.Parameters.AddWithValue("@articleIdenty", articleId);
							command.Parameters.AddWithValue("@tagname", tag.TagName);
							command.ExecuteNonQuery();
						}
					}

					transaction.Commit();
				}
				catch (Exception e)
				{
					this.logger.Error(e.Message);
					transaction?.Rollback();
				}
			}
		}

		public int GetArticleIdByCaption(string caption)
		{
			int result = 0;
			string sqlCommand = "exec sp_get_articleId_by_caption @caption";

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@caption", caption);

				try
				{
					this.SqlConnection.Open();
					result = (int) cmd.ExecuteScalar();
				}
				catch (Exception e)
				{
					this.logger.Error(e.Message);
				}
			}

			return result;
		}

		public void UpdateArticle(Article article)
		{
			string sqlCommandUpdateArticle =
				"exec sp_update_article @articleId, @caption, @text, @landuage, @video, @image, @categoryId";
			SqlTransaction transaction = null;

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				try
				{
					this.SqlConnection.Open();
					transaction = this.SqlConnection.BeginTransaction();

					using (SqlCommand cmd = new SqlCommand(sqlCommandUpdateArticle, this.SqlConnection, transaction))
					{
						cmd.Parameters.AddWithValue("@articleId", article.ArticleId);
						cmd.Parameters.AddWithValue("@caption", article.Caption);
						cmd.Parameters.AddWithValue("@text", article.Text);
						cmd.Parameters.AddWithValue("@landuage", article.Language);
						cmd.Parameters.AddWithValue("@video", article.Video ?? (object) DBNull.Value);
						cmd.Parameters.AddWithValue("@image", article.Image);
						cmd.Parameters.AddWithValue("@categoryId", article.CategoryId);
						cmd.ExecuteNonQuery();
					}

					string sqlCommandDeleteTagsArticlesArticleid = " exec sp_delete_tags_articles @articleId";
					using (SqlCommand cmd = new SqlCommand(
						sqlCommandDeleteTagsArticlesArticleid,
						this.SqlConnection,
						transaction))
					{
						cmd.Parameters.AddWithValue("@articleId", article.ArticleId);
						cmd.ExecuteNonQuery();
					}

					string sqlCommandWriteTags = "exec sp_save_tags_for_atricle @articleIdenty, @tagname";
					foreach (var tag in article.Tags)
					{
						using (SqlCommand command = new SqlCommand(
							sqlCommandWriteTags,
							this.SqlConnection,
							transaction))
						{
							command.Parameters.AddWithValue("@articleIdenty", article.ArticleId);
							command.Parameters.AddWithValue("@tagname", tag.TagName);
							command.ExecuteNonQuery();
						}
					}

					transaction.Commit();
				}
				catch (Exception e)
				{
					this.logger.Error(e.Message);
					transaction.Rollback();
				}
			}
		}

		public void DeleteArticle(int articleId)
		{
			string sqlCommand = "exec sp_delete_article @articleid";
			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@articleid", articleId);

				try
				{
					this.SqlConnection.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					this.logger.Error(e.Message);
				}
			}
		}

		private List<Tag> GetTagsByArticleId(int articleId)
		{
			List<Tag> tags = new List<Tag>();

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "exec sp_GetTagsByArticleID @articleID";

				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@articleID", articleId);
				this.SqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						tags.Add(
							new Tag
							{
								TagId = (int) reader["TagID"],
								TagName = (string) reader["TagName"]
							});
					}
				}
			}

			return tags;
		}

		public List<Article> GetArticlesOfUser(string userName, int maxArticlesInPage, int page = 1)
		{
			List<Article> result = new List<Article>();
			string sqlCommand = "exec sp_get_articles_of_user @username, @maxArticles, @page";

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@username", userName ?? (object)DBNull.Value);
				cmd.Parameters.AddWithValue("@maxArticles", maxArticlesInPage);
				cmd.Parameters.AddWithValue("@page", page);
				this.SqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(
							new Article
							{
								ArticleId = (int) reader["ArticleId"],
								Caption = (string) reader["Caption"],
								Text = (string) reader["Text"],
								Language = (string) reader["Language"],
								Date = (DateTime) reader["Date"],
								User = new User
								{
									Name = (string) reader["Name"]
								}
							});
					}
				}
			}

			return result;
		}

		public List<Article> GetRandomArticles(int excludeId)
		{
			List<Article> result = new List<Article>();

			string sqlCommand = "exec sp_get_random_articles @excludeId";

			using (this.SqlConnection=new SqlConnection(this.ConnectionString))
			{
				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);
				cmd.Parameters.AddWithValue("@excludeId", excludeId);

				this.SqlConnection.Open();

				using (SqlDataReader reader=cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(new Article
						{
							ArticleId = (int)reader["ArticleID"],
							Caption = (string)reader["Caption"],
							Image = (string)reader["Image"]
						});
					}
				}
			}
			return result;
		}
	}
}