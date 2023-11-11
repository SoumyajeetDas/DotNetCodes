using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDesignerFromDatabse
{
    
    class Program
    {
        ADONetEntities Empcontext;
        //List<Emp> liemp;

        public void DisplayData()
        {
            Empcontext = new ADONetEntities();


            var z = Empcontext.Emps;
            IQueryable<Emp> liemp = Empcontext.Emps;
            IEnumerable<Emp> liemp3 = Empcontext.Emps;

            IEnumerable<Emp> liemp1 = Empcontext.Emps.ToList<Emp>();
            List<Emp> liemp2 = Empcontext.Emps.ToList<Emp>();
            IList<Emp> liemp5 = Empcontext.Emps.ToList<Emp>();
            


            foreach (var x in liemp)
            {
                Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}", x.id, x.Name, x.Gender));
            }
            Console.WriteLine();


            var iq = (from x in Empcontext.Emps orderby x.Name select x);
            //foreach(Emp x in iq) {
            //    Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}", x.id, x.Name, x.Gender));
            //}
            //Console.WriteLine();


            //var liemp1 = (from x in Empcontext.Emps orderby x.Name select x);
            //foreach (var x in liemp1)
            //{
            //    Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}", x.id, x.Name, x.Gender));
            //}


            //Console.WriteLine();
            //var liemp2 = (from x in Empcontext.Emps select x).ToList<Emp>();
            //foreach (var x in liemp2)
            //{
            //    Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}", x.id, x.Name, x.Gender));
            //}
            Console.WriteLine();
            var liemp4 = (from x in Empcontext.Emps group x by x.Gender into sgroup orderby sgroup.Key select sgroup);
            foreach (var x in liemp4)
            {
                Console.WriteLine("Gender = " + x.Key);
                foreach (var t in x)
                {
                    Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}", t.id, t.Name, t.Gender));
                }

            }




        }

        public void InsertData(Emp e)
        {
            Empcontext = new ADONetEntities();
            Console.WriteLine("Enter the customer name");
            e.Name = Console.ReadLine();
            Console.WriteLine("Enter the Gender");
            e.Gender = Console.ReadLine();
            Console.WriteLine("Enter the Dept_Id");
            e.Dept_Id = Convert.ToInt32(Console.ReadLine());
            Empcontext.Emps.Add(e);
            int x = Empcontext.SaveChanges();
            Console.WriteLine($"{x} no of data inserted");

        }


        public void UpdateData()
        {
            Empcontext = new ADONetEntities();
            Console.WriteLine("Enter the empId");
            int empid = Convert.ToInt32(Console.ReadLine());
            //Emp e = Empcontext.Emps.FirstOrDefault<Emp>(x => x.id == empid);
            Emp e = (Empcontext.Emps.Find(empid));// This returns the entity that is the Employee object. If element not found returns null

            Console.WriteLine("Enter 1. for updating name 2. for updating Gender");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch(ch)
            {
                case 1:
                    if(e!=null)
                    {
                        Console.WriteLine("Enter the name");
                        string name = Console.ReadLine();
                        e.Name = name;
                        int x = Empcontext.SaveChanges();
                        Console.WriteLine($"{x} no of data inserted");
                    }
                    else
                    {
                        Console.WriteLine("Emp Id not found");

                    }
                    break;
                case 2:
                    if (e != null)
                    {
                        Console.WriteLine("Enter the Gender");
                        string gender = Console.ReadLine();
                        e.Gender = gender;
                        int x = Empcontext.SaveChanges();
                        Console.WriteLine($"{x} no of data inserted");
                    }
                    else
                    {
                        Console.WriteLine("Emp Id not found");

                    }
                    break;

                default:
                    Console.WriteLine("Wrong Choice");
                    break;

            }

        }
        public void DeleteData()
        {
            Empcontext = new ADONetEntities();
            Console.WriteLine("Enter the empId");
            int empid = Convert.ToInt32(Console.ReadLine());
            Emp e = Empcontext.Emps.FirstOrDefault<Emp>(x => x.id == empid); // Returns the entity. If not found returns null
            if(e!=null)
            {
                Empcontext.Emps.Remove(e);
                int x = Empcontext.SaveChanges();
                Console.WriteLine($"{x} no of data inserted");


            }
            else
            {
                Console.WriteLine("Emp Id not found");

            }
        }
        
        static void Main(string[] args)
        {
            Program p = new Program();
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
                        Emp e = new Emp();
                        p.InsertData(e);
                        
                        break;

                    case 2:
                        p.UpdateData();
                        break;
                    case 3:
                        p.DeleteData();
                        break;

                    case 4:
                        p.DisplayData();
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;

                }

                Console.WriteLine("Do you want to continue [y/n]");
                s = Console.ReadLine().ToLower()[0];
            } while (s == 'y');

            Console.ReadKey();
            Console.ReadKey();

        }
    }
}
