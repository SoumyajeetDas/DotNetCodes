using Library_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Repository.IRepository
{
    public interface ILibraryRepository
    {
        Task<List<Library>> Books();
        Task<bool> Create(Library lib);
        Task<Library> Details(int id);
    }
}
