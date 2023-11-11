using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Understanding_the_connection_ways_and_Retrieve_the_Data_from_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initiation of connection b/w DB and application with the help of Connection strings

            //Here con the connection string which is used to store info to connect the DB to the application.

            //SqlConnection con = new SqlConnection(@"data source = LAPTOP-AD63JEEU\SOUMYA; database = storedprocedurecheck; integrated security = SSPI");

            // In place of database in the above line you could have also written Initial Catalog
            // SSPI --> Secure Support Provide Database --> A security for Windows Authentication



            //SqlConnection con = new SqlConnection(@"data source = LAPTOP-AD63JEEU\SOUMYA; database = storedprocedurecheck; user id = ""; password="");
            //If using Sql server authentication you neec to specify the user id and password.
            #endregion


            #region Initiation of Connection in another way and executing the sql command

            //SqlConnection helps to initiate the connection. Here it receives a string parameter
            string myconn = ConfigurationManager.ConnectionStrings["FirstConn"].ConnectionString; //--> This way is the proposed way


            //Here the above connection String is written in the App.Config file.
            //Now in place of ConnectionStrings["FirstConn"] you could have also used ConnectionStrings[0] which is used to mention the
            //first Connection string in the App.config file.
            //We also need to add System.Configuration as Reference and add namepace --> using System.Configuration to use the above code




            //One thing to remenber you cannot create a second instance of SqlConnection without closing the first one. There can be only one instance of SqlConnection present in the total code.
            

            using (SqlConnection con = new SqlConnection(myconn))   //Here when writing this using we need not to write the con.close() explicitly
            {
                SqlCommand cmd = new SqlCommand("Select * from Emp order by Id", con);  //SqlCommand tells to execute the command on the con which knows the databse and the table associated to it.
                con.Open(); //Opening the connection
                SqlDataReader dr = cmd.ExecuteReader(); //ExecuteReader() - Used to execute a select statement and return the rows returned by the select statement as a DataReader. Return type of this method is DataReader.
                                                        
                #region Using dr.Read() to read one line at a time and then moves to the next record. If not found returns false otherwise true
                //Console.WriteLine(dr.HasRows);
                //if(dr.HasRows) --> HasRows returns true if there is one or more row otherwise returns false.
                //{
                //    dr.Read();
                //    Console.WriteLine("Id = "+dr["Id"].ToString());
                //}
                #endregion




                while (dr.Read())
                {
                    Console.WriteLine("Id = " + dr["Id"].ToString());
                    Console.WriteLine("Name = " + dr["Name"].ToString());
                    Console.WriteLine("Gender = " + dr["Gender"].ToString());
                    Console.WriteLine("DeptId = " + dr["Dept_id"].ToString());
                    Console.WriteLine("==========================================================================================");
                    Console.WriteLine();

                }
                //Console.WriteLine(dr.Read());
                dr.Close(); // One thing to remember you cannot create two instances of DataReader. To create a new one need to need to close the previous one
            } // No need to write con.Close() as you are making the connection in the using.

            //con.Close();
            

            #endregion
        }
    }
}
