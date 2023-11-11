using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnitityFrameworkWithASP.NETCore.Models;

namespace EnitityFrameworkWithASP.NETCore.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options):base(options)
        {

        }
        public DbSet<Books> Books { set; get; }
        
        //public DbSet<EnitityFrameworkWithASP.NETCore.Models.BookModel> BookModel { get; set; }  
    }
}
