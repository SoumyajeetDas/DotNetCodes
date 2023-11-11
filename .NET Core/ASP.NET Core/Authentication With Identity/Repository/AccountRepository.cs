using Authentication_With_Identity.Models;
using Authentication_With_Identity.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_With_Identity.Repository
{
   
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

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
                UserName = signUpModel.UserName
            };

            var result = await userManager.CreateAsync(user, signUpModel.Password);
            if (!result.Succeeded)
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

            var k = await userManager.IsInRoleAsync(user, "Admin");
            if(user!=null && await userManager.CheckPasswordAsync(user,signInModel.Password) && await userManager.IsInRoleAsync(user, "Admin")) // Now when username is found matches the password
            {
                var result = await signInManager.PasswordSignInAsync
                    (signInModel.UserName, signInModel.Password,false, false);

                if (result.Succeeded)
                {
                    return "Success";
                }
                else
                {
                    return "Failure";
                }
            }
            return "Wrong Password or Role";
            
        }

        public async Task<bool>Logout()
        {
            await signInManager.SignOutAsync();
            return true;
        }
    }
}
