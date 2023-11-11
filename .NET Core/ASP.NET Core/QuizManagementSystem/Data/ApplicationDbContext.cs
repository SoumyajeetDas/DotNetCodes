using Microsoft.EntityFrameworkCore;
using QuizManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<QuestionPaper> QuestionPapers { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<Result> Results { set; get; }
        public DbSet<Admin> Admins { set; get; }

    }
}
