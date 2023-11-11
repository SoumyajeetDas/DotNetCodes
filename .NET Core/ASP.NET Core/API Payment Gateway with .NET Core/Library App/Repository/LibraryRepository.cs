using Library_App.Data;
using Library_App.Models;
using Library_App.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Repository
{ 
    public class LibraryRepository : ILibraryRepository
    {
        private readonly ApplicationDbContext context;

        public LibraryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Library>> Books()
        {
            return await context.Libraries.ToListAsync();
        }

        public async Task<bool> Create(Library lib)
        {
            if(lib!=null)
            {
                try
                {
                    await context.Libraries.AddAsync(lib);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
                
            }

            else
            {
                return false;
            }
        }

        public async Task<Library> Details(int id)
        {
            if(id==0)
            {
                return null;
            }
            else
            {
                return await context.Libraries.FindAsync(id);
            }
        }
    }
}
