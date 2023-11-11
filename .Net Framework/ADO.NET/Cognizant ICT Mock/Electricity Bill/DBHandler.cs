using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Electricity_Bill
{
    class DBHandler
    {
        //Implement the methods as per the description
        public SqlConnection GetConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["EConn"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            return con;
        }
    }
}
