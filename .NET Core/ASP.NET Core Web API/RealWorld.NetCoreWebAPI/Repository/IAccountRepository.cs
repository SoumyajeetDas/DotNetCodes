using Microsoft.AspNetCore.Identity;
using RealWorld.NetCoreWebAPI.Models;
using System.Threading.Tasks;

namespace RealWorld.NetCoreWebAPI.Repository
{
    public interface IAccountRepository
    {
        Task<string> AdminSignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signInModel);
        Task<string> UserSignUpAsync(SignUpModel signUpModel);
        //Task<string> SignUpAsync(SignUpModel signUpModel);

    }
}