using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Common;
using InfoPortal.DAL.Abstract;

namespace InfoPortal.DAL.Concrete
{
	public class ArticleContext : IArticleContext
	{
		readonly log4net.ILog _logger =
			log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private readonly SqlConnection _sqlConnection;

		public List<Article> Articles { get; set; }

		public ArticleContext()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DbInfoPortal"].ConnectionString;
			_sqlConnection = new SqlConnection(connectionString);

			Articles = GetAllArticles();
		}

		private List<Article> GetAllArticles()
		{
			List<Article> articles = new List<Article>();
			//Исправить запрос
			using (_sqlConnection)
			{
				_sqlConnection.Open();
				string sqlCommand = "select * from GetDataArticles";
				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);

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
							UserID = (int) reader["UserID"],
							Language = reader["Language"] as string,
							Video = reader["Video"] as string,
							Image = reader["Image"] as string,
							User = new User
							{
								Name = (string) reader["Name"],
								Email = (string) reader["E-mail"]
							},
							CategoryID = (int) reader["CategoryID"],
							Category = (string) reader["CategoryName"]
						});
					}

					reader.Close();
				}
			}

			return articles;
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