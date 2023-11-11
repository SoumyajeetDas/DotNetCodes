using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class SimpleController : ControllerBase
    {
        [HttpGet("getall")]
        [HttpGet("get-all")]
        [HttpGet("Simple/getall")]
        public string GetAll()
        {
            return "GetAll";
        }


        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "Your id is " + id;
        }

        
    }
}
