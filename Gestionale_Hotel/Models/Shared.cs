using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gestionale_Hotel.Models
{
    public class Shared
    {
        public static SqlConnection GetConnectionDB()
        {
            string connection = ConfigurationManager.ConnectionStrings["DB_Hotel"].ToString();
            SqlConnection sql = new SqlConnection(connection);
            return sql;
        }

        public static SqlDataReader GetReaderAfterSql(string SQLCommandText, SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(SQLCommandText, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            return reader;
        }
    }
}