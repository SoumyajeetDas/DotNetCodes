using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BindingController : ControllerBase
    {
        //[BindProperty]
        //public int id { set; get; }
        //[BindProperty]
        //public string Name { set; get; }

        //[BindProperty(SupportsGet =true)]
        [BindProperty]
        public Employee emp { set; get; }

        //[HttpGet("")]
        [HttpPost("")]
        public IActionResult AddCountry()
        {
            return Ok("Name = "+emp.Name + " Id = "+ emp.Id);
        }

        [HttpGet("AddCountry1/{id}")]
        public IActionResult AddCountry1([FromQuery]Employee emp, [FromRoute] int id)
        {
            return Ok("Name = " + emp.Name + " Id = " + emp.Id + " Id from Route : "+id);
        }

        
        [HttpPost("AddCountry2/{id}")]
        public IActionResult AddCountry2([FromRoute] int id, [FromBody]Employee emp )
        {
            return Ok("Name = " + emp.Name + " Id = " + id);
        }

        [HttpGet("AddCountry3")]
        public IActionResult AddCountry3([FromQuery] int id, [FromForm] Employee emp)
        {
            return Ok("Name = " + emp.Name + " Id = " + id);
        }

        [HttpPost("AddCountry4/{id}")]
        public IActionResult AddCountry4([FromRoute] int id, [FromHeader] Employee emp)
        {
            return Ok("Name = " + emp.Name + " Id = " + id);
        }
    }
}
