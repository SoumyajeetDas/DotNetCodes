using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ParkyWebAPI.Data;
using ParkyWebAPI.Models;
using ParkyWebAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParkyWebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;
        public UserRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public User Login(User user)
        {
            
            var userobj = Authenticate(user);
            if (userobj != null)
            {
                userobj.Token = GenerateJSONWebToken(userobj.UserName, userobj.Role);
                return userobj;
            }
            return null;

        }
        public User Authenticate(User user)
        {

            User obj = context.users.Where(x => x.UserName == user.UserName && x.Password == user.Password).Select(x => new User()
            {
                UserName = x.UserName,
                Password = x.Password,
                Role = x.Role

            }).FirstOrDefault();
            return obj;

        }
        private string GenerateJSONWebToken(string username, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("username",username),
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

        public User Register(User user)
        {
            if(user!=null)
            {
                User userobj = new User()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Role = user.Role
                };
                context.users.Add(userobj);
                context.SaveChanges();
                userobj.Password = String.Empty;
                return userobj;
            }
            return null;
        }

        public bool IsUniqueUser(string name)
        {
            var obj = context.users.SingleOrDefault(obj => obj.UserName == name);
            if (obj == null)
                return true;
            return false;

        }

    }
}
