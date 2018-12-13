using System.Configuration;
using System.Data.SqlClient;

namespace InfoPortal.DAL.Implements
{
	public class DbContext
	{
		protected readonly log4net.ILog logger =
			log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		protected SqlConnection SqlConnection;

		protected readonly string ConnectionString =
			ConfigurationManager.ConnectionStrings["DbInfoPortal"].ConnectionString;
	}
}
