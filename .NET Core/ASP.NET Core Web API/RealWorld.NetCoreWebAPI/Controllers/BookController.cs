using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RealWorld.NetCoreWebAPI.Models;
using RealWorld.NetCoreWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealWorld.NetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Admin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Admin")]
    public class BookController : ControllerBase
    {
        public IBookRepository bookrepository = null;
        public BookController(IBookRepository bookrepository)
        {
            this.bookrepository = bookrepository;
        }


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("~/getallbooks")]       
        public async Task<IActionResult> GetAllBooks()
        {
            var booklist = await bookrepository.GetAllBooks();
            return Ok(booklist);
        }

        [HttpGet("~/getbookbyid/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await bookrepository.GetBookById(id);
            if (book == null)
                return NotFound();
            else
                return Ok(book);
        }

        [HttpPost("~/AddBook")]
        [ProducesResponseType(StatusCodes.Status201Created,Type=typeof(int))]
        public async Task<IActionResult> AddBook([FromBody]BookModel model)
        {
            var book = await bookrepository.AddBook(model);
            return CreatedAtAction("GetBookById", new { id = book.Id, controller = "Book" }, book.Id);
        }


        [HttpPut("~/UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook([FromBody]BookModel model,[FromRoute] int id)
        {
            await bookrepository.UpdateBook(id, model);
            return Ok();
        }

        [HttpPatch("~/UpdatePartially/{id}")]
        public async Task<IActionResult>UpdateBookPartially([FromBody] JsonPatchDocument model, [FromRoute] int id)
        {
            await bookrepository.UpdatePartiallyBook(id, model);
            return Ok();
        }

        [HttpDelete("~/DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await bookrepository.DeleteBook(id);
            return LocalRedirect("~/getallbooks");
        }
    }
}
