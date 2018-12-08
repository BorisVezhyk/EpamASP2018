using System.Configuration;
using System.Data.SqlClient;

namespace InfoPortal.Domain.Concrete
{
	public class DBContext
	{
		protected readonly log4net.ILog _logger =
			log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		protected SqlConnection _sqlConnection;

		protected readonly string _connectionString =
			ConfigurationManager.ConnectionStrings["DbInfoPortal"].ConnectionString;
	}
}
