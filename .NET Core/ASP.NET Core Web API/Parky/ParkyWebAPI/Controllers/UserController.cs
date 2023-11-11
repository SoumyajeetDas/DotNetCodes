using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyWebAPI.Models;
using ParkyWebAPI.Models.DTOs;
using ParkyWebAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpPost("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(User))]
        public IActionResult Authenticate([FromBody] LoginDTO loginDTO)
        {
            if(loginDTO==null)
            {
                return BadRequest("No data wrt parameter");
            }

            var logindtoobj = mapper.Map<User>(loginDTO);
            var obj = userRepository.Login(logindtoobj);

            if (obj == null)
                return BadRequest(new { Message = "User Not present" });
            return Ok(obj);
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public IActionResult Register([FromBody] RegisterDTO registerDTO)
        {
            if (registerDTO == null)
            {
                return BadRequest("No data wrt parameter");
            }

            var logindtoobj = mapper.Map<User>(registerDTO);

            var obj = userRepository.IsUniqueUser(logindtoobj.UserName);
            if(obj==false)
            {
                return BadRequest("User Already Exists");
            }

            var userregister = userRepository.Register(logindtoobj);
            if(userregister==null)
            {
                return BadRequest("User is null");
            }
            return Ok(userregister);
        }
    }
}
