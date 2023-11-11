using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EntityFrameworkwithASP.NetMVC.Models
{
    public class SupplierProductCategoryContext : DbContext
    {
        public SupplierProductCategoryContext():base("name=EntityFrameWorkASP.NETMVCConn")
        {

        }

        public virtual DbSet<Product>Products { set; get; }
        public virtual DbSet<Category>Categories { set; get; }
        public virtual DbSet<Supplier>Suppliers { set; get; }
    }
}