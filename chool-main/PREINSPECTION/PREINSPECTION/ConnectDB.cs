using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace PREINSPECTION
{
    internal static class ConnectDB
    {   
        static public SqlConnection connectDB()
        {
            SqlConnection sqlConnection_TEAMDB = new SqlConnection("SERVER = localhost;  DATABASE = DB_QA; Integrated Security=True;");
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
