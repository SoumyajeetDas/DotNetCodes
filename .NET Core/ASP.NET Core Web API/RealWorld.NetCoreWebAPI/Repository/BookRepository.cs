using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using RealWorld.NetCoreWebAPI.Data;
using RealWorld.NetCoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealWorld.NetCoreWebAPI.Repository
{ 
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDBContext context;
        private readonly IMapper mapper;
        public BookRepository(BookStoreDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {

            var booklistDB = await context.Books.ToListAsync();

            if (booklistDB.Any())
            {

                //var books = await context.Books.Select(obj => new BookModel()
                //{
                //    Id = obj.Id,
                //    Description = obj.Description,
                //    Title = obj.Title
                //}).ToListAsync();
                var books = await context.Books.Select(obj => 
                mapper.Map<BookModel>(obj)).ToListAsync();
                return books;
            }
            else
                return new List<BookModel>(){
                    new BookModel() { Id = 0, Description = "Not There", Title = "Not There" }
                };

            
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(x=>x.Id==id);

            if(book!=null)
            {
                //BookModel bm = new BookModel()
                //{
                //    Id = book.Id,
                //    Description=book.Description,
                //    Title=book.Title
                //};

                //return bm;

                return mapper.Map<BookModel>(book);
            }
            return null;
        }

        public async Task<BookModel> AddBook(BookModel model)
        {
            //var newbook = new Books()
            //{
            //    Title = model.Title,
            //    Description = model.Description,
            //    Id = model.Id
            //};


            var newbook = mapper.Map<Books>(model);

            await context.Books.AddAsync(newbook);
            await context.SaveChangesAsync();

            //var newbookmodel = new BookModel()
            //{
            //    Title = newbook.Title,
            //    Description = newbook.Description,
            //    Id = newbook.Id
            //};

            var newbookmodel = mapper.Map<BookModel>(newbook);

            return newbookmodel;

        }

        public async Task UpdateBook(int id, BookModel model)
        {
            //var book = await context.Books.FindAsync(id);
            //if(book!=null)
            //{
            //    book.Description = model.Description;
            //    book.Title = model.Title;
            //    await context.SaveChangesAsync();
            //}

            //var book = new Books()
            //{
            //    Id = id,
            //    Description = model.Description,
            //    Title = model.Title
            //};

            var book = mapper.Map<Books>(model);

            context.Books.Update(book);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePartiallyBook(int id , JsonPatchDocument model)
        {
            var book = await context.Books.FindAsync(id);
            if (book != null)
            {
                model.ApplyTo(book);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteBook(int id)
        {
            var book = new Books() { Id = id };
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }
    }
}
