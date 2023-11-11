using Microsoft.AspNetCore.Http;
using QuizManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Repository.IRepository
{
    public interface IAdminUploadFileRepository
    {
        Task Delete(int id);
        List<QuestionPaper> ExtractQuestions();
        List<Student> ExtractStudents();
        Task<List<Result>> GetResults();
        Task<List<Result>> ShowResult();
        Task<string> UploadQuestionPaper(IFormFile file,int? time);
        Task<string> UploadStudentList(IFormFile file);
    }
}
