namespace InfoPortal.DAL.Implements
{
	using System.Configuration;
	using System.Data.SqlClient;

	public class DbContext
	{
		protected readonly log4net.ILog logger =
			log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		protected SqlConnection SqlConnection;

		protected readonly string ConnectionString =
			ConfigurationManager.ConnectionStrings["DbInfoPortal"].ConnectionString;
	}
}