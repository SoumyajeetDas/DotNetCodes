using FirstAPIPractise.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstAPIPractise
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(): base("FirstWebAPI.NetConn")
        {

        }
        public DbSet<User> Users { set; get; }
    }
}