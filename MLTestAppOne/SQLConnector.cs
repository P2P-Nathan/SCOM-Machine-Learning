using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLTestAppOne
{
    internal class SQLConnector
    {
        public void getSqlData()
        {
            try
            {
                string ConString = "Server=Infra-SQL01.cookdown.local;Database=Ops16DW;User Id=NathanSQL;Password=JamieJo!!;";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    // Creating SqlCommand object   
                    SqlCommand cm = new SqlCommand("select top 10 * from dbo.Discovery", connection);
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    SqlDataReader sdr = cm.ExecuteReader();
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["DiscoveryRowId"] + ",  " + sdr["DiscoveryGuid"] + ",  " + sdr["DiscoverySystemName"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }

        public SqlConnection GetSqlConnection()
        {
            string ConString = "Server=Infra-SQL01.cookdown.local;Database=Ops16DW;User Id=NathanSQL;Password=JamieJo!!;";
            SqlConnection connection = new SqlConnection(ConString);
            connection.Open();
            return connection;
        }
    }
}
