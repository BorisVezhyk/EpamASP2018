namespace InfoPortal.DAL.Implements
{
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using Common;
	using Interfaces;

	public class CategoryContext : DbContext, ICategoryContext
	{
		public List<Category> GetAllCategories()
		{
			List<Category> result = new List<Category>();

			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				string sqlCommand = "select * from Categories";
				SqlCommand cmd = new SqlCommand(sqlCommand, this.SqlConnection);

				this.SqlConnection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(
							new Category
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