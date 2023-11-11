using QuizManagementSystem.Models;
using QuizManagementSystem.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Repository.IRepository
{
    public interface IAdminAccountRepository
    {
        bool AdminDuplicateCheck(string username);
        Admin Find(ForgotPassword fp);
        AdminDto Login(Admin admin);
        Task<Admin> Register(Admin admin);
        Task<bool> Update(Admin admin);
    }
}
