using Microsoft.EntityFrameworkCore;
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
    public class AdminAccountRepository : IAdminAccountRepository
    {
        private ApplicationDbContext context;
        private readonly IConfiguration configuration;

        public AdminAccountRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<Admin> Register(Admin admin)
        {
            if (admin != null)
            {
                admin.Role = "Admin";
                await context.Admins.AddAsync(admin);
                await context.SaveChangesAsync();
               
                return admin;
            }
            return null;
        }

        public bool AdminDuplicateCheck(string username)
        {
            var res = context.Admins.Any(x => x.Username == username);
            return res;

        }

        public AdminDto Login(Admin admin)
        {
            var response = String.Empty;
            var adminobj = Authenticate(admin);
            if (adminobj != null)
            {
                var tokenString = GenerateJSONWebToken(adminobj.Username, adminobj.Role);
                adminobj.Token = tokenString;
                return adminobj;
            }
            return null;

        }
        public AdminDto Authenticate(Admin admin)
        {

            var obj = context.Admins.Where(x => x.Username == admin.Username && x.Password == admin.Password && x.Role=="Admin").Select(x => new Admin()
            {
                Username = x.Username,
                Password = x.Password,


            }).FirstOrDefault();

            if (obj == null)
            {
                return null;
            }

            AdminDto objdto = new AdminDto()
            {
                Username = obj.Username,
                Password = obj.Password,
                Role = "Admin"
            };
            return objdto;

        }

        private string GenerateJSONWebToken(string adminname, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,adminname),
                new Claim("role",role)

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

        public Admin Find(ForgotPassword fp)
        {
            var res = context.Admins.SingleOrDefault(x => x.Username == fp.Username);

            
            return res;
        }

        public async Task<bool> Update(Admin admin)
        {

            try
            {
                context.Admins.Update(admin);
                await context.SaveChangesAsync();
                return true;

            }
            catch
            {
                return false;
            }
           
        }
    }
}
