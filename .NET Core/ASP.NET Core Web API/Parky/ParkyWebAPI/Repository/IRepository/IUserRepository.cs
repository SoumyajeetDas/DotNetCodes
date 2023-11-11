using ParkyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string name);
        User Login(User user);
        User Register(User user);
    }
}
