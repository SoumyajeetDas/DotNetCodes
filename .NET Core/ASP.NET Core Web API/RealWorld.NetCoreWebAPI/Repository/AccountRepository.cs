using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RealWorld.NetCoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealWorld.NetCoreWebAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        //private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        public AccountRepository(UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
        }

        //Admin SignUp
        public async Task<string> AdminSignUpAsync(SignUpModel signUpModel)
        {
            var userExist = await userManager.FindByNameAsync(signUpModel.UserName); //Checking if the same user is present in the databse table with the help of userName.
            if (userExist != null)
            {
                return "User Exists";
            }
            var user = new ApplicationUser()
            {
                Email = signUpModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(), //The security timestamp is used for tracking changes made to the user profile. It is used for security purposes when important properties of a user change, such as changing the password.
                                                           // Guid --> Globally Unique Identifier
                UserName =signUpModel.UserName
            };

            var result = await userManager.CreateAsync(user, signUpModel.Password);
            if(!result.Succeeded)
            {
                return "Not Succeded";
            }
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin)) // If Admin is not present as a role hen add it to the Database
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (await roleManager.RoleExistsAsync(UserRoles.Admin)) // If the role Admin is present add the to that role.
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            return "Success";
        }


        //User SignUp
        public async Task<string> UserSignUpAsync(SignUpModel signUpModel)
        {
            var userExist = await userManager.FindByNameAsync(signUpModel.UserName);
            if (userExist != null)
            {
                return "User Exists";
            }
            var user = new ApplicationUser()
            {
                Email = signUpModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = signUpModel.UserName
            };

            var result = await userManager.CreateAsync(user, signUpModel.Password);
            if (!result.Succeeded)
            {
                return "Not Succeded";
            }
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (await roleManager.RoleExistsAsync(UserRoles.User))
            {
                await userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return "Success";
        }




        public async Task<string> LoginAsync(SignInModel signInModel)
        {
            var user = await userManager.FindByNameAsync(signInModel.UserName); // First Matches by username

            if(user!=null && await userManager.CheckPasswordAsync(user,signInModel.Password)) // Now when username is found matches the password
            {
                var userroles = await userManager.GetRolesAsync(user);
                var authclaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,signInModel.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                foreach (var roles in userroles)
                {
                    authclaims.Add(new Claim(ClaimTypes.Role, roles)); //Adds whatever Role the user have. roles is in strig type
                }
                var authSignKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authclaims,
                signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256Signature)
                );
                return new JwtSecurityTokenHandler().WriteToken(token); // Returns the token in the coded way in the string format.
            }
            return null;
            
        }
    }
}
