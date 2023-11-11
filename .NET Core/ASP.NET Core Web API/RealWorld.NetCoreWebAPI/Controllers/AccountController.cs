using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealWorld.NetCoreWebAPI.Data;
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
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [HttpPost("adminsignup")]
        public async Task<IActionResult> AdminSignUp([FromBody] SignUpModel signUpModel)
        {
            var result = await accountRepository.AdminSignUpAsync(signUpModel);
            if(result=="User Exists")
                return StatusCode(StatusCodes.Status500InternalServerError, new Response() { Status = "Unsuccessful", Message = "User Exists Alredy" });
            else if(result=="Not Succeded")
                return StatusCode(StatusCodes.Status500InternalServerError, new Response() { Status = "Unsuccessful", Message = "User Cannot be Created" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new Response() { Status = "Successful", Message = "User Created Successfully" });
            
        }


        [HttpPost("usersignup")]
        public async Task<IActionResult> UserSignUp([FromBody] SignUpModel signUpModel)
        {
            var result = await accountRepository.UserSignUpAsync(signUpModel);
            if (result == "User Exists")
                return StatusCode(StatusCodes.Status500InternalServerError, new Response() { Status = "Unsuccessful", Message = "User Exists Alredy" });
            else if (result == "Not Succeded")
                return StatusCode(StatusCodes.Status500InternalServerError, new Response() { Status = "Unsuccessful", Message = "User Cannot be Created" });
            else
                return StatusCode(StatusCodes.Status200OK, new Response() { Status = "Successful", Message = "User Created Successfully" });

        }


        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] SignInModel signInModel)
        {
            var result = await accountRepository.LoginAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
