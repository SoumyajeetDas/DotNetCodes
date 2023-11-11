using EnitityFrameworkWithASP.NETCore.Data;
using EnitityFrameworkWithASP.NETCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnitityFrameworkWithASP.NETCore.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookStoreDbContext context = null;
        public BookRepository(BookStoreDbContext context)
        {
            this.context = context;
        }

        public async Task AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                CreatedOn = model.CreatedOn

            };

            await context.Books.AddAsync(newBook);
            await context.SaveChangesAsync();

        }

        public async Task<List<BookModel>> GetAllBooks() // Return type is List<BookModel>
        {
            var books = new List<BookModel>();
            var allbooks = await context.Books.ToListAsync();

            if (allbooks.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Id = book.Id,
                        Author = book.Author,
                        Description = book.Description,
                        Title = book.Title,
                        CreatedOn = book.CreatedOn
                    });

                }
            }
            return books;
        }

        public async Task<BookModel> GetBook(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book != null)
            {
                BookModel books = new BookModel()
                {
                    Author = book.Author,
                    Description = book.Description,
                    Id = book.Id,
                    Title = book.Title,
                    CreatedOn = book.CreatedOn
                };
                return books;
            }
            return null;
        }

        public async Task Edit(BookModel model)
        {
            Books book = new Books()
            {
                Id = model.Id,
                Author = model.Author,
                Title = model.Title,
                CreatedOn = model.CreatedOn,
                Description = model.Description
            };
            context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Delete(BookModel model)
        {
            Books book = new Books()
            {
                Id = model.Id,
                Author = model.Author,
                Title = model.Title,
                CreatedOn = model.CreatedOn,
                Description = model.Description
            };
            context.Remove(book);
            await context.SaveChangesAsync();
        }
    }
}
