/// <summary>
/// Jory A. Wernette
/// Created: 2021/05/10
/// 
/// This class creates a connection to the 
/// databse
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Jory A. Wernette
    /// Created: 2021/05/10
    /// 
    /// This method references the sql
    /// </summary>
    internal static class DBConnection
    {
        // this is the only place to connect to the db
        private static string connectionString =
           // @"Data Source=localhost;Initial Catalog=ygo_db;Integrated Security=True";
            @"Data Source=.\SQLExpress;Initial Catalog=ygo_db;Integrated Security=True";

        public static SqlConnection GetDBConnection()
        {
            var conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}
