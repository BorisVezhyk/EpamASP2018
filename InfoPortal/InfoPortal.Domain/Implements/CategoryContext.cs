using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Common;
using InfoPortal.DAL.Interfaces;

namespace InfoPortal.DAL.Implements
{
	public class CategoryContext : ICategoryContext
	{
		public List<Category> Categories { get; set; }

		private readonly SqlConnection sqlConnection;

		public CategoryContext()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DbInfoPortal"].ConnectionString;
			sqlConnection = new SqlConnection(connectionString);
			Categories = GetAllCategories();
		}

		private List<Category> GetAllCategories()
		{
			List<Category> result = new List<Category>();

			using (sqlConnection)
			{
				string sqlCommand = "select * from Categories";
				SqlCommand cmd = new SqlCommand(sqlCommand, sqlConnection);

				sqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(new Category
						{
							CategoryId = (int) reader["CategoryID"],
							CategoryName = (string) reader["CategoryName"]
						});
					}
				}
			}
			return result;
		}
	}
}