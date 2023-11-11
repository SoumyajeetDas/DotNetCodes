using QuizManagementSystem.Models;
using QuizManagementSystem.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Repository.IRepository
{
    public interface IStudentAccountRepository
    {
        StudentDto Login(Student student);
    }
}
