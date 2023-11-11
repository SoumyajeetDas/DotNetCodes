using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            SupplierProductCategoryContext spcontext = new SupplierProductCategoryContext();

            //Category c = new Category()
            //{
            //    Cat_Type = "Electronics"
            //};
            //spcontext.Categories.Add(c);
            //int x = spcontext.SaveChanges();
            //Console.WriteLine($"{x} no of rows affected");

            //Supplier s = new Supplier()
            //{
            //    Sup_name = "Soumyajeet",
            //    Sup_phno = 7044139099

            //};
            //spcontext.Suppliers.Add(s);
            //int x = spcontext.SaveChanges();
            //Console.WriteLine($"{x} no of rows affected");

            Product p = new Product()
            {
                Prod_Name = "Desktop",
                Prod_Type = "Electronics",
                Sup_Id = 1,
                Cat_Id = 1
            };
            
            spcontext.Products.Add(p);
            int x = spcontext.SaveChanges();
            Console.WriteLine($"{x} no of rows affected");
            Console.ReadKey();






        }
    }
}
