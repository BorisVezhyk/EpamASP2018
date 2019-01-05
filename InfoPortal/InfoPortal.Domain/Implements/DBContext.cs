namespace InfoPortal.DAL.Implements
{
	using System;
	using System.Data;
	using System.Data.SqlClient;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Linq;

	public class DbContext
	{
		protected readonly log4net.ILog logger =
			log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		protected SqlConnection SqlConnection;

		protected readonly string ConnectionString =
			ConfigurationManager.ConnectionStrings["DbInfoPortal"].ConnectionString;

		private SqlParameter ToConvertSqlParams(SqlCommand command, string name, object value)
		{
			var p = command.CreateParameter();
			p.ParameterName = name;
			p.Value = value ?? (object) DBNull.Value;
			return p;
		}

		protected IEnumerable<IDataRecord> ExecuteQuery(string command, params object[] args)
		{
			using (this.SqlConnection = new SqlConnection(this.ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand(command, SqlConnection))
				{
					var parameters = args.Select(
						(value, index) => this.ToConvertSqlParams(cmd, index.ToString(), value));

					cmd.Parameters.AddRange(parameters.ToArray());

					SqlConnection.Open();

					using (var reader = cmd.ExecuteReader())
					{
						foreach (IDataRecord record in reader)
							yield return record;
					}
				}
			}
		}

		protected object ExecScalar(string command, params object[] args)
		{
			try
			{
				using (this.SqlConnection = new SqlConnection(this.ConnectionString))
				{
					using (SqlCommand cmd = new SqlCommand(command, this.SqlConnection))
					{
						var parameters = args.Select(
							(value, index) => this.ToConvertSqlParams(cmd, index.ToString(), value));
						cmd.Parameters.AddRange(parameters.ToArray());

						this.SqlConnection.Open();

						return cmd.ExecuteScalar();
					}
				}
			}
			catch (Exception e)
			{
				this.logger.Error(e.Message);
				return null;
			}
		}
	}
}