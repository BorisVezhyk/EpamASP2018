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

		private readonly SqlConnection _sqlConnection;

		public CategoryContext()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DbInfoPortal"].ConnectionString;
			_sqlConnection = new SqlConnection(connectionString);
			Categories = GetAllCategories();
		}

		private List<Category> GetAllCategories()
		{
			List<Category> result = new List<Category>();

			using (_sqlConnection)
			{
				string sqlCommand = "select * from Categories";
				SqlCommand cmd = new SqlCommand(sqlCommand, _sqlConnection);

				_sqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(new Category
						{
							CategoryID = (int) reader["CategoryID"],
							CategoryName = (string) reader["CategoryName"]
						});
					}
				}
			}
			return result;
		}
	}
}