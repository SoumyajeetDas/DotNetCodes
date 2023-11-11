using ConnectingWebAPIandMVC.Data;
using ConnectingWebAPIandMVC.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingWebAPIandMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext context;

        public StudentController(StudentDBContext context)
        {
            this.context = context;
        }

        [HttpGet("getallstudents")]
        public async Task<IActionResult> GetAllStudent()
        {
            return Ok(await context.Students.ToListAsync());
        }

        [HttpGet("getstudentid/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var stud = await context.Students.FindAsync(id);
            if(stud==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stud);
            }
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(Student student)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                await context.Students.AddAsync(student);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
