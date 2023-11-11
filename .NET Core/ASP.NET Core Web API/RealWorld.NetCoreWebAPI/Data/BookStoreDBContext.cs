using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealWorld.NetCoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealWorld.NetCoreWebAPI.Data
{
    public class BookStoreDBContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
        {

        }

        public DbSet<Books> Books { set; get; } // This will create a DB with the same name
    }
}
