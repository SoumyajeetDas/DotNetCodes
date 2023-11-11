using QuizManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Repository.IRepository
{
    public interface IStudentQuestionRepository
    {
        Task<bool> CheckUser(string username);
        Task<List<QuestionPaper>> GetQuestions();
        Task<string> UploadResult(string username, double percentage);
    }
}
