using Authentication_With_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_With_Identity.Repository.IRepository
{
    public interface IAccountRepository
    {
        Task<string> AdminSignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signInModel);
        Task<bool> Logout();
        Task<string> UserSignUpAsync(SignUpModel signUpModel);
    }
}
