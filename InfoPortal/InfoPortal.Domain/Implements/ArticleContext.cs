namespace InfoPortal.DAL.Implements
{
	using System.Data;
	using System.Linq;
	using Common;
	using Interfaces;
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;

	public class ArticleContext : DbContext, IArticleContext
	{
		private Article GetArticleFromRecord(IDataRecord record)
		{
			Article article;
			article = new Article
			{
				ArticleId = (int) record["ArticleID"],
				Caption = (string) record["Caption"],
				Text = (string) record["Text"],
				Date = (DateTime) record["Date"],
				Language = record["Language"] as string,
				Video = record["Video"] as string,
				Image = record["Image"] as string,
				User = new User
				{
					Name = (string) record["Name"],
				},

				Category = (string) record["CategoryName"],
				CategoryId = (int) record["CategoryID"]
			};
			return article;
		}

		private List<Tag> GetTagsByArticleId(int articleId)
		{
			List<Tag> tags = new List<Tag>();

			string sqlCommand = "exec sp_GetTagsByArticleID @articleID=@0";

			var records = base.ExecuteQuery(sqlCommand, articleId);

			foreach (var record in records)
			{
				tags.Add(
					new Tag
					{
						TagId = (int) record["TagID"],
						TagName = (string) record["TagName"]
					});
			}

			return tags;
		}

		public Article GetArticle(int articleId)
		{
			Article article = null;

			try
			{
				string sqlCommand = "exec sp_get_article_by_articleID @articleId=@0";

				var records = base.ExecuteQuery(sqlCommand, articleId);

				article = this.GetArticleFromRecord(records.FirstOrDefault());

				if (article != null)
				{
					article.Tags = this.GetTagsByArticleId(articleId);
					return article;
				}
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
			}

			return null;
		}

		public List<Article> GetArticlesForMainPage(int maxArticlesInPage, string category, int page = 1)
		{
			List<Article> articles = new List<Article>();
			try
			{
				string sqlCommand = "exec sp_GetArticles @category = @0, @maxArticlesForPage = @1, @page= @2";
				var records =
					base.ExecuteQuery(sqlCommand, category, maxArticlesInPage, page);

				foreach (var rdr in records)
				{
					articles.Add(this.GetArticleFromRecord(rdr));
				}
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
			}

			return articles;
		}

		public List<Article> GetSearchByNamesOfArticles(string searchQuery, int pageSize, int page = 1)
		{
			List<Article> result = new List<Article>();

			try
			{
				string sqlCommand =
					"exec sp_get_articles_by_caption @page=@0, @maxArticlesForPage=@1, @captionArticle=@2";
				var records = base.ExecuteQuery(sqlCommand, page, pageSize, searchQuery);

				foreach (var record in records)
				{
					result.Add(this.GetArticleFromRecord(record));
				}
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
			}

			return result;
		}

		public List<Article> GetSearchByDate(string searchQuery, int pageSize, int page = 1)
		{
			List<Article> result = new List<Article>();

			try
			{
				string sqlCommand =
					"exec sp_get_articles_by_date @page=@0, @maxArticlesForPage=@1, @dateSearch=@2";

				var records = base.ExecuteQuery(sqlCommand, page, pageSize, searchQuery);

				foreach (var record in records)
				{
					result.Add(this.GetArticleFromRecord(record));
				}
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
			}

			return result;
		}

		public List<Article> GetSearchByTagName(string searchQuery, int pageSize, int page = 1)
		{
			List<Article> result = new List<Article>();
			try
			{
				string sqlCommand =
					"exec sp_get_articles_by_tags @page=@0, @maxArticlesForPage=@1, @tagName=@2";

				var records = base.ExecuteQuery(sqlCommand, page, pageSize, searchQuery);

				foreach (var record in records)
				{
					result.Add(this.GetArticleFromRecord(record));
				}
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
			}

			return result;
		}

		public List<Article> GetArticlesOfUser(string userName, int maxArticlesInPage, int page = 1)
		{
			List<Article> result = new List<Article>();
			try
			{
				string sqlCommand = "exec sp_get_articles_of_user @userName=@0, @maxArticlesForPage=@1, @page=@2";

				var records = base.ExecuteQuery(sqlCommand, userName, maxArticlesInPage, page);

				foreach (var record in records)
				{
					result.Add(this.GetArticleFromRecord(record));
				}
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
			}

			return result;
		}

		public List<Article> GetRandomArticles(int excludeId)
		{
			List<Article> result = new List<Article>();

			try
			{
				string sqlCommand = "exec sp_get_random_articles @withOutId=@0";

				var records = base.ExecuteQuery(sqlCommand, excludeId);

				foreach (var record in records)
				{
					result.Add(this.GetArticleFromRecord(record));
				}
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
			}

			return result;
		}

		public int GetCountArticles(string category)
		{
			string sqlCommmand = "exec sp_get_count_articles_by_category @category=@0";

			object result = base.ExecScalar(sqlCommmand, category);
			if (result != null)
			{
				return (int) result;
			}

			return 0;
		}

		public int GetCountArticlesSearchResult(int selectSearch, string searchQuery)
		{
			string sqlCommand = "exec sp_get_count_result_search @select=@0, @query=@1";

			object result = base.ExecScalar(sqlCommand, selectSearch, searchQuery);
			if (result != null)
			{
				return (int) result;
			}
			return 0;
		}

		public int GetCountArticlesOfUser(string userName)
		{
			string sqlCommand = "exec sp_get_count_articles_of_user @userName=@0";
			object result = base.ExecScalar(sqlCommand, userName);
			if (result!=null)
			{
				return (int) result;
			}

			return 0;
		}

		public int GetArticleIdByCaption(string caption)
		{
			string sqlCommand = "exec sp_get_articleId_by_caption @caption=@0";
			object result = base.ExecScalar(sqlCommand, caption);

			if (result!=null)
			{
				return (int) result;
			}

			return 0;
		}

		//need refactoring
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

		public void UpdateArticle(Article article)
		{
			string sqlCommandUpdateArticle =
				"exec sp_update_article @articleId, @caption, @text, @lang, @video, @image, @categoryId";
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
						cmd.Parameters.AddWithValue("@lang", article.Language);
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
	}
}