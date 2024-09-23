using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
namespace AdonetCrud.DataAccessLayer
{
    public class AppAdoBase
    {
        string ConnectionString = "Data Source = localhost; Database = ProductAdo; Integrated Security = false; User ID = sa; password = root; TrustServerCertificate = true";

//For holding connection object throughout the class.
 internal SqlConnection Connection;

        public SqlConnection OpenConnection()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
           
            return Connection;
        }
        
        public int ExecuteSql(string sql)
        {
            //Opening connection and hold in the property
            OpenConnection();

            SqlCommand command = new SqlCommand();
            //Feeding sql to the command
            command.CommandText = sql;
            //Feeding connection to the command
            command.Connection = Connection;
            //Reading Affected entities count
            int rawAffected = command.ExecuteNonQuery();
            return rawAffected;
        }
    }
}
