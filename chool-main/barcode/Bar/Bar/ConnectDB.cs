using Microsoft.Data.SqlClient;

namespace Bar
{

    public class ConnectDB
    {

        static public SqlConnection connectDB_TEAMDB()
        {
            SqlConnection sqlConnection_TEAMDB = new SqlConnection("SERVER = 172.28.140.136, 1433; DATABASE = DB_QA; UID = sa; PWD = 1qaz2wsx3edc;TrustServerCertificate=True");

            try
            {
                sqlConnection_TEAMDB.Open();
                return sqlConnection_TEAMDB;
            }
            catch (Exception e)
            {
                Log.writeLog(e.ToString());
                return null;
            }

        }
    }
}