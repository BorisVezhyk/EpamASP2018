using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Common;
using InfoPortal.Domain.Abstract;

namespace InfoPortal.Domain.Concrete
{
	public class CategoryContext : ICategoryContext
	{
		public List<Category> Categories { get; set; }

		private SqlConnection sqlConnection = null;

		public CategoryContext()
		{
			Categories = GetAllCategories();
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

		private List<Category> GetAllCategories()
		{
			List<Category> result=new List<Category>();
			string sqlCommand = "select * from Categories";

			OpenConnection();

			using (SqlCommand cmd=new SqlCommand(sqlCommand,sqlConnection))
			{
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					result.Add(new Category
					{
						CategoryID = (int)reader["CategoryID"],
						CategoryName = (string)reader["CategoryName"]
					});
				}
			}
			CloseConnection();
			return result;
		}
	}
}
