using System.Data.Entity;

namespace CodeFirst
{
    class SupplierProductCategoryContext : DbContext
    {
        public SupplierProductCategoryContext() : base("name =CodeFirstConn")
        {

        }
        public virtual DbSet<Supplier> Suppliers { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<Category> Categories { set; get; }
    }
}
