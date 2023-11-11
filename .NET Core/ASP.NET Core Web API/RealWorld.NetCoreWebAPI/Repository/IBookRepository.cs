using Microsoft.AspNetCore.JsonPatch;
using RealWorld.NetCoreWebAPI.Data;
using RealWorld.NetCoreWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealWorld.NetCoreWebAPI.Repository
{
    public interface IBookRepository
    {
        Task<BookModel> AddBook(BookModel model);
        Task DeleteBook(int id);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task UpdateBook(int id, BookModel model);
        Task UpdatePartiallyBook(int id, JsonPatchDocument model);
    }
}