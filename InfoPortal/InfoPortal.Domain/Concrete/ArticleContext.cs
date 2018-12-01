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
		private SqlConnection sqlConnection = null;

		public List<Article> Articles { get; set; }

		public ArticleContext()
		{
			Articles = GetAllArticles();
		}

		private void OpenConnection()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DbInfoPortal"].ConnectionString;
			sqlConnection=new SqlConnection(connectionString);
			sqlConnection.Open();
		}

		private void CloseConnection()
		{
			sqlConnection.Close();
		}

		private List<Article> GetAllArticles()
		{
			List<Article> articles = new List<Article>();
			string sqlCommand = "select * from Articles,Users";

			OpenConnection();

			using (SqlCommand cmd=new SqlCommand(sqlCommand,sqlConnection))
			{
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					articles.Add(new Article
					{
						ArticleID = (int)reader["ArticleID"],
						Caption = (string)reader["Caption"],
						Text = (string)reader["Text"],
						Date = (DateTime)reader["Date"],
						UserID = (int)reader["UserID"],
						Language = reader["Language"] as string,
						Video = reader["Video"] as string,
						Image = reader["Image"] as string,
						User = new User
						{
							Name = (string)reader["Name"],
							Email = (string) reader["E-mail"]
						}
					});
				}
				reader.Close();
			}
			CloseConnection();
			return articles;
		}

		public void InsertNewArticle(Article article)
		{
			string sqlCommand = "INSERT INTO Articles (Caption,Text,Date,Language,Video,Image,UserID) " +
			                    "VALUES(@Caption,@Text,@Date,@Language,@Video,@Image,@UserID)";
			OpenConnection();

			using (SqlCommand cmd=new SqlCommand(sqlCommand,sqlConnection))
			{
				cmd.Parameters.AddWithValue("@Caption", article.Caption);
				cmd.Parameters.AddWithValue("@Text", article.Text);
				cmd.Parameters.AddWithValue("@Date", article.Date);
				cmd.Parameters.AddWithValue("@Language", article.Language);
				cmd.Parameters.AddWithValue("@Video", article.Video);
				cmd.Parameters.AddWithValue("@Image", article.Image);
				cmd.Parameters.AddWithValue("@UserID", article.UserID);

				cmd.ExecuteNonQuery();
			}
			CloseConnection();
		}

		public void UpdateArticle(Article article)
		{
			string sqlCommand = "UPDATE Articles SET " +
			                    "Caption=@Caption," +
			                    "Text=@Text," +
			                    "Date=@Date," +
			                    "Language=@Language," +
			                    "Video=@Video," +
			                    "Image=@Image";
			OpenConnection();

			using (SqlCommand cmd=new SqlCommand(sqlCommand,sqlConnection))
			{
				cmd.Parameters.AddWithValue("@Caption", article.Caption);
				cmd.Parameters.AddWithValue("@Text", article.Text);
				cmd.Parameters.AddWithValue("@Date", article.Date);
				cmd.Parameters.AddWithValue("@Language", article.Language);
				cmd.Parameters.AddWithValue("@Video", article.Video);
				cmd.Parameters.AddWithValue("@Image", article.Image);

				cmd.ExecuteNonQuery();
			}
			CloseConnection();
		}

		public void DeleteArticle(int articleID)
		{
			string sqlCommand = "DELETE FROM Articles " +
			                    "WHERE ArticleID=@id";

			OpenConnection();
			using (SqlCommand cmd = new SqlCommand(sqlCommand,sqlConnection) )
			{
				cmd.Parameters.AddWithValue("@id", articleID);

				cmd.ExecuteNonQuery();
			}
			CloseConnection();
		}
	}
}
