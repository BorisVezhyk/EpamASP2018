namespace InfoPortal.DAL.Implements
{
	using System.Data;
	using System.Collections.Generic;
	using Common;
	using Interfaces;

	public class CategoryContext : DbContext, ICategoryContext
	{
		private Category GetCategoryFromRecord(IDataRecord record)
		{
			return new Category
			{
				CategoryId = (int) record["CategoryID"],
				CategoryName = (string) record["CategoryName"]
			};
		}

		public List<Category> GetAllCategories()
		{
			List<Category> result = new List<Category>();
			string sqlCommand = "select * from Categories";

			var records = base.ExecuteQuery(sqlCommand);

			foreach (var record in records)
			{
				result.Add(this.GetCategoryFromRecord(record));
			}

			return result;
		}
	}
}