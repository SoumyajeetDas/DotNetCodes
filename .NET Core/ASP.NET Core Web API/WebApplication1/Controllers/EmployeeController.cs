using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        List<Employee> li;
        public EmployeeController()
        {
            li = new List<Employee>()
            {
                new Employee()
                {
                    Id=1,
                    Name ="Soumyajeet",
                    Age=20

                },
                new Employee()
                {
                    Id=2,
                    Name ="Sehroz",
                    Age=23

                },

            };
        }

        [HttpGet("Employees200")]
        public IActionResult GetEmployees200(int id)
        {
            if (id == 0)
                return NotFound();

            return Ok(new List<Employee>()
            {
                new Employee()
                {
                    Id=1,
                    Name ="Soumyajeet",
                    Age=20

                },
                new Employee()
                {
                    Id=2,
                    Name ="Sehroz",
                    Age=23

                },

            });
        }

        [HttpGet("Employees200Special")]
        public IActionResult GetEmployees200Special(List<Employee> li)
        {
            return Ok(li);
        }
        [HttpGet("Employees202")]
        public IActionResult GetEmployees202()
        {
            List<Employee> li = new List<Employee>()
            {
                new Employee()
                {
                    Id=1,
                    Name ="Soumyajeet",
                    Age=20

                },
                new Employee()
                {
                    Id=2,
                    Name ="Kaka",
                    Age=23

                },

            };

            return AcceptedAtAction("GetEmployees200", li);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetEmployeeById201(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                Employee emp = li.FirstOrDefault(x=>x.Id==id);
                return Ok(emp);
            }
        }

        [HttpPost("getemployees201")]
        public IActionResult GetEmployees201(Employee emp)
        {
            li.Add(emp);
            
            return CreatedAtAction("GetEmployeeById201",new { id=emp.Id},emp);
        }
    }
}
