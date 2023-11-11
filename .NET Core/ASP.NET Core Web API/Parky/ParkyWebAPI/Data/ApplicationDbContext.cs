using Microsoft.EntityFrameworkCore;
using ParkyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<NationalPark> nationalparks { set; get; }
        public DbSet<Trail> trails { set; get; }
        public DbSet<User> users { set; get; }
    }
}
