using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;




// Disconnected Architecture Explained well by Abhishek Sir Pdf


namespace Disconnected_Architecture
{
    class DisconnectedArchitecture
    {
        //SqlDataAdapter da;
        //SqlCommandBuilder cmb;
        //DataSet ds;

        public DisconnectedArchitecture()
        {

        }
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DisConnectedConn"].ConnectionString;
            }
           
        }
        public SqlConnection _sqlconn
        {
            set;get;
        }

        public void DataInsert(Customer c)
        {
            _sqlconn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Customer",_sqlconn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            da.Fill(ds, "JustCustomer");

            DataRow drow = ds.Tables["JustCustomer"].NewRow(); // .NewRow() creates a row with the same schema or the same column name and returns this row.
            //drow["Id"] = c.Id;
            drow["Name"] = c.Name;
            drow["Order_id"] = c.Order_id;

            ds.Tables["JustCustomer"].Rows.Add(drow); //Adds row to the dataset
            int x = da.Update(ds, "JustCustomer");  // Update Also returns no of rows affected.
            Console.WriteLine($"{x} Inserted Successfully");
        }

        public void DataUpdate()
        {
            _sqlconn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Customer", _sqlconn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            da.Fill(ds, "JustCustomer");
            Console.WriteLine("Enter the EmpId");
            int EmpId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 1.to update the name and 2. to update the Order_id");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch(ch)
            {
                case 1:

                    Console.WriteLine("Enter the name");
                    string empname = Console.ReadLine();
                    DataRow drow = ds.Tables["JustCustomer"].Rows.Find(EmpId); // Returns the row specified by the Primary Key  
                    if (drow != null)
                    {
                        drow["Name"] = empname;
                        int x = da.Update(ds, "JustCustomer");
                        Console.WriteLine($"{x} rows updated successfully");

                    }
                    else
                    {
                        Console.WriteLine("EmpId not found");
                    }
                    break;

                case 2:

                    Console.WriteLine("Enter the Dept_id");
                    int Order_id = Convert.ToInt32(Console.ReadLine());
                    DataRow drow1 = ds.Tables["JustCustomer"].Rows.Find(EmpId);
                    if(drow1 !=null)
                    {
                        drow1["Order_id"] = Order_id;
                        int x = da.Update(ds, "JustCustomer");
                        Console.WriteLine($"{x} rows updated");

                    }
                    break;

                default:
                    Console.WriteLine("Wrong Choice");
                    break;


            }
        }

        public void DataDelete()
        {
            _sqlconn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Customer", _sqlconn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            da.Fill(ds, "JustCustomer");
            Console.WriteLine("Enter the Employee Number");
            int EmpId = Convert.ToInt32(Console.ReadLine());
            ds.Tables["JustCustomer"].Rows.Find(EmpId).Delete(); // Delete a data row.
            int x = da.Update(ds, "JustCustomer");
            Console.WriteLine($"{x} rows deleted");
        }

        public void DisplayData()
        {
            _sqlconn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Customer", _sqlconn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            da.Fill(ds, "JustCustomer");

            Console.WriteLine("Employee Details");
            Console.WriteLine();
            foreach(DataRow drow in ds.Tables["JustCustomer"].Rows) // .Rows returns the collection of rows in the table
            {
                Console.WriteLine("EmpId : "+drow["Id"]);
                Console.WriteLine("Emp Name  : "+drow["Name"]);
                Console.WriteLine("Order _id  : "+drow["Order_Id"]);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }

 
    public class Customer
    {
        public int Id
        {
            set;get;
        }
        public string Name
        {
            set;get;
        }
        public int Order_id
        {
            set;get;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DisconnectedArchitecture d = new DisconnectedArchitecture();
            char s;

            do
            {
                Console.WriteLine("Enter 1 for Insert data");
                Console.WriteLine("Enter 2 for Update data");
                Console.WriteLine("Enter 3 for Delete data");
                Console.WriteLine("Enter 4 for Display data");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Customer c = new Customer();
                        Console.WriteLine("Enter the name");
                        c.Name = Console.ReadLine();
                        Console.WriteLine("Enter the Order_Id");
                        c.Order_id = Convert.ToInt32(Console.ReadLine());

                        d.DataInsert(c);
                        break;

                    case 2:
                        d.DataUpdate();
                        break;
                    case 3:
                        d.DataDelete();
                        break;

                    case 4:
                        d.DisplayData();
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;

                }

                Console.WriteLine("Do you want to continue [y/n]");
                s = Console.ReadLine().ToLower()[0];
            } while (s == 'y');
            
            Console.ReadKey();

        }
    }
}
