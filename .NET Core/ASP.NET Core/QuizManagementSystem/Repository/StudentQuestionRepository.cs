using Microsoft.EntityFrameworkCore;
using QuizManagementSystem.Data;
using QuizManagementSystem.Models;
using QuizManagementSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QuizManagementSystem.Repository
{
    public class StudentQuestionRepository : IStudentQuestionRepository
    {
        private ApplicationDbContext context;
        public StudentQuestionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<QuestionPaper>> GetQuestions()
        {
            return await context.QuestionPapers.ToListAsync();
        }

        public async Task<string> UploadResult(string username,double percentage)
        {
            Result res = new Result()
            {
                Username = username,
                percentage = percentage
            };
            try
            {
                await context.Results.AddAsync(res);
                await context.SaveChangesAsync();
              

                return "Success";
            }
            catch
            {
                return "Failure";
            }
            
        }

        public async Task<bool> CheckUser(string username)
        {
            var res = await context.Results.AnyAsync(x => x.Username == username);
            return res;
        }

        public void EmailSend(Email ec)
        {
            string subject = ec.subject;
            string body = ec.body;
            string to = ec.to;

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("soumyajeetdas1998@gmail.com");
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("soumyajeetdas1998@gmail.com", "Kiit@123");
            smtp.Send(mm);
        }
    }
}
