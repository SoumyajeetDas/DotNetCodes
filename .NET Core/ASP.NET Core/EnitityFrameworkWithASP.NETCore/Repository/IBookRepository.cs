using EnitityFrameworkWithASP.NETCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnitityFrameworkWithASP.NETCore.Repository
{
    public interface IBookRepository
    {
        Task AddNewBook(BookModel model);
        Task Delete(BookModel model);
        Task Edit(BookModel model);
        public Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBook(int id);
    }
}