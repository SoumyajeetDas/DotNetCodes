using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizManagementSystem.Data;
using QuizManagementSystem.Models;
using QuizManagementSystem.Models.DTOs;
using QuizManagementSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuizManagementSystem.Repository
{
    public class StudentAccountRepository : IStudentAccountRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;

        public StudentAccountRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public StudentDto Login(Student student)
        {
            var response = String.Empty;
            var studentobj = Authenticate(student);
            if (studentobj != null)
            {
                var tokenString = GenerateJSONWebToken(studentobj.Username, studentobj.Role);
                studentobj.Token = tokenString;
                return studentobj;
            }
            return null;

        }
        public StudentDto Authenticate(Student student)
        {

            Student obj = context.Students.Where(x => x.Username == student.Username && x.Password == student.Password).Select(x => new Student()
            {
                Username = x.Username,
                Password = x.Password,
               

            }).FirstOrDefault();

            if(obj==null)
            {
                return null;
            }

            StudentDto objdto = new StudentDto()
            {
                Username = obj.Username,
                Password = obj.Password,
                Role = "Student"
            };
            return objdto;

        }

        private string GenerateJSONWebToken(string studentname, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,studentname),
                new Claim("role","Student")

            };
            var token = new JwtSecurityToken(

               issuer: configuration["Jwt:Issuer"],
               audience: configuration["JWT:ValidAudience"],
               claims: claims,
               expires: DateTime.Now.AddDays(1),
               signingCredentials: credentials
               );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
