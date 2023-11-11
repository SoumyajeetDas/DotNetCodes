using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Stored_Procedure
{
    class Procedure
    {
        public Procedure()
        {

        }
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ProcConn"].ConnectionString;
            }
            
        }
        public SqlConnection _sqlconn
        {
            set;get;
        }

        public void procwithoutvariable()
        {
            try
            {
                _sqlconn = new SqlConnection(ConnectionString);
                _sqlconn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "getProcEmp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = _sqlconn;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(string.Format("{0,-20}{1,-20}", dr["Name"], dr["Gender"]));

                }
                dr.Close();
                _sqlconn.Close();

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void procwithvariable()
        {
            try
            {
                _sqlconn = new SqlConnection(ConnectionString);
                _sqlconn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "getProcEmpParam";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = _sqlconn;
                Console.WriteLine("Enter the gender");
                string gen = Console.ReadLine();
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 20).Value = gen;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(string.Format("{0,-20}{1,-20}", dr["Name"], dr["Gender"]));

                }
                dr.Close();
                _sqlconn.Close();


            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void procwithout()
        {
            try
            {

                _sqlconn = new SqlConnection(ConnectionString);
                _sqlconn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Procwithout";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = _sqlconn;
                Console.WriteLine("Enter the gender");
                string gen = Console.ReadLine();
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 10).Value = gen;
                SqlParameter outP = new SqlParameter("@count", SqlDbType.Int); //SqlParameter --> see in the Word file
           
                outP.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outP);
                cmd.ExecuteNonQuery(); // You need to execute the query within the stored procedure otherwise it will return Null for this outP
                //dr.Close();
                Console.WriteLine("Count = "+outP.Value);
                _sqlconn.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
           
    

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Procedure p = new Procedure();
            p.procwithoutvariable();
            p.procwithvariable();
            p.procwithout();

            Console.ReadKey();
        }
    }
}
