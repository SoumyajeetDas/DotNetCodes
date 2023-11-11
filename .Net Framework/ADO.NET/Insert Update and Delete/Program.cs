using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Insert_Update_and_Delete
{
    

    class Employee
    {


        public int Emp_id
        {
            set; get;
        }
        public string name
        {
            set;get;
        }
        public string gender
        {
            set;get;
        }
        public int Dept_id
        {
            set;get;
        }
        
    }

    class EmpDatabaseDml
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;


        #region Create and end connection


        public EmpDatabaseDml()
        {
            string myconn = ConfigurationManager.ConnectionStrings["CRUDcon"].ConnectionString;
            con = new SqlConnection(myconn);
            con.Open();
        }
        ~EmpDatabaseDml()
        {
            //When destructor get called connection automatically gets closed
        }


        #endregion


        #region Insertion of Data


        public void InsertData(Employee e)
        {
            com = new SqlCommand();
            com.CommandText = "insert into Emp values(@Name,@Gender,@Dept_id)"; //CommandText : Used to specify the SQL statement you want to execute.
            com.Connection = con;
            //The same thing can be written by --> com = new SqlCommand("insert into Emp values(@Name,@Gender,@Dept_id)",con);



            // Id is autoincreemented so not taken input

            com.Parameters.Add("@Name", SqlDbType.VarChar,20).Value = e.name; // .Add--> Adds a SqlParameter to the SqlParameterCollection(Represents a collection of parameters associated with a SqlCommand and their respective mappings to columns in a DataSet)
            com.Parameters.Add("@Gender", SqlDbType.VarChar,20).Value = e.gender;
            com.Parameters.Add("@Dept_id", SqlDbType.Int).Value = e.Dept_id;
            //com.Parameters.Add("id", SqlDbType.Float).Value = movie.Id;
            int i = com.ExecuteNonQuery(); //Used to execute an SQL statement that doesn’t return any value like insert, update and delete. Return type of this method is int and it returns the no. of rows effected by the given statement.

            Console.WriteLine($"{i} no of rows affected");


        }

        #endregion



        #region Update Data in the table
        

        public void UpdateData()
        {
            int EmpId;
            Console.WriteLine("Enter the Emp Id ");
            EmpId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Press 1 to Update the Name and Press 2 to Update the Dept_ID");
            int ch = Convert.ToInt32(Console.ReadLine());
            int i;
            switch (ch)
            {

                case 1:
                    Console.WriteLine("Enter the updated name ");
                    string name = Console.ReadLine();
                    com = new SqlCommand("update Emp set Name = @name where Id= @EmpId", con);
                    com.Parameters.Add("@name", SqlDbType.VarChar,20).Value = name;
                    com.Parameters.Add("@EmpId", SqlDbType.Int).Value = EmpId;
                    i = com.ExecuteNonQuery();
                    Console.WriteLine($"{i} no of rows affected");
                    //com.Dispose();
                    break;
                case 2:
                    Console.WriteLine("Enter the updated Dept_id ");
                    int d_id = Convert.ToInt32(Console.ReadLine());
                    com = new SqlCommand("update Emp set Dept_id= @d_id where Id= @EmpId", con);
                    com.Parameters.Add("@d_id", SqlDbType.Int).Value = d_id;
                    com.Parameters.Add("@EmpId", SqlDbType.Int).Value = EmpId;
                    i = com.ExecuteNonQuery();
                    Console.WriteLine($"{i} no of rows affected");
                    //com.Dispose();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }


        }


        #endregion



        #region Delete Data


        public void DeleteData()
        {
            int EmpId;
            Console.WriteLine("Enter the Emp Id ");
            EmpId = Convert.ToInt32(Console.ReadLine());
            com = new SqlCommand("delete from Emp where Id = @EmpId", con);
            com.Parameters.Add("@EmpId", SqlDbType.Int).Value = EmpId;
            int i = com.ExecuteNonQuery();
            Console.WriteLine($"{i} no of rows affected and deleted successfully");
            
        }

        public void DisplayData()
        {
            com = new SqlCommand("select * from Emp ", con);
            dr = com.ExecuteReader();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Employee Details");
            Console.WriteLine();
            while (dr.Read())
            {
                Console.WriteLine("EmpId : " + dr["Id"]);
                Console.WriteLine("EmpName : " + dr["Name"]);
                Console.WriteLine("Gender : " + dr["Gender"]);
                Console.WriteLine("Emp_DeptId : " + dr["Dept_id"]);
                Console.WriteLine();
                Console.WriteLine();

            }
            Console.WriteLine("************************************************************");
            dr.Close();
            Console.WriteLine();
            Console.WriteLine();
          
        }

        #endregion


    }
    class Program
    {
        static void Main(string[] args)
        {
            char x;
            EmpDatabaseDml ed = new EmpDatabaseDml();
            do
            {
                Console.WriteLine("Enter any option");
                Console.WriteLine("1 to Display");
                Console.WriteLine("2 to Add Employee");
                Console.WriteLine("3 to Update Employee");
                Console.WriteLine("4 to Delete Employee");
                Console.WriteLine();

                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        ed.DisplayData();
                        break;
                    case 2:
                        Employee e = new Employee();

                        //Id is auto increemented so input not taken

                        Console.WriteLine("Enter the name");
                        e.name = Console.ReadLine();
                        Console.WriteLine("Enter the gender");
                        e.gender = Console.ReadLine();
                        Console.WriteLine("Enter the Dept Id");
                        e.Dept_id = Convert.ToInt32(Console.ReadLine());
                        ed.InsertData(e);
                        break;
                    case 3:
                        ed.UpdateData();
                        break;
                    case 4:
                        ed.DeleteData();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Do you want to continue? [y/n]");
                x = Console.ReadLine().ToLower()[0];
            } while (x == 'y');
        }
    }
}
