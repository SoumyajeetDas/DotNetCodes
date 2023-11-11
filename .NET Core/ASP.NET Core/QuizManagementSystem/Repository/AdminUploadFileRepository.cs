using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using QuizManagementSystem.Data;
using QuizManagementSystem.Models;
using QuizManagementSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace QuizManagementSystem.Repository
{
    public class AdminUploadFileRepository : IAdminUploadFileRepository
    {
        private IHostingEnvironment hostingEnvironment;
        private ApplicationDbContext context;
        public AdminUploadFileRepository(IHostingEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.context = context;
        }

        public async Task<string> UploadQuestionPaper(IFormFile file,int? time)
        {
            string filename = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";

            //File Uploaded the content is coiped into the new file that is being created.
            using (FileStream fileStream = System.IO.File.Create(filename))
            {
                file.CopyTo(fileStream); //Copying the contents of the file uploaded to the newly created file
                fileStream.Flush();
            }

            var code = await GetCodeQuestions(file.FileName,time); //GetStudentList will extract the list of entries in the file and will convert in to List<Student>
            return code;
        }


        public async Task<string> UploadStudentList(IFormFile file)
        {
            string filename = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";

            //File Uploaded the content is coiped into the new file that is being created.
            using (FileStream fileStream = System.IO.File.Create(filename))
            {
                file.CopyTo(fileStream); //Copying the contents of the file uploaded to the newly created file
                fileStream.Flush();
            }

            var code = await GetCodeStudents(file.FileName); //GetStudentList will extract the list of entries in the file and will convert in to List<Student>
            return code;
        }



        private async Task<string> GetCodeQuestions(string fname,int? time)
        {
            List<QuestionPaper> questionPapers = new List<QuestionPaper>();
            var filename = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fname;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            try
            {
                using (var stream = System.IO.File.Open(filename, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        await deletealldataindatabseQustions();
                        while (reader.Read())
                        {
                            QuestionPaper qp = new QuestionPaper()
                            {
                                Time = time,
                                Question = reader.GetValue(0).ToString(),
                                FirstOption = reader.GetValue(1).ToString(),
                                SecondOption = reader.GetValue(2).ToString(),
                                ThirdOption = reader.GetValue(3).ToString(),
                                FourthOption = reader.GetValue(4).ToString(),
                                CorrectResult = reader.GetValue(5).ToString()

                            };

                            context.QuestionPapers.Add(qp);
                            await context.SaveChangesAsync();
                        }
                    }
                }
                System.IO.File.Delete(filename);
                return "Success";
            }


            catch
            {
                if ((System.IO.File.Exists(filename)))
                {
                    System.IO.File.Delete(filename);
                }

                return "Failure";
            }

        }

        private async Task<string> GetCodeStudents(string fname)
        {
            List<Student> questionPapers = new List<Student>();
            var filename = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fname;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            try
            {
                using (var stream = System.IO.File.Open(filename, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        await deletealldataindatabseStudents();
                        while (reader.Read())
                        {
                            Student st = new Student()
                            {
                                Username = reader.GetValue(0).ToString(),
                                Password = reader.GetValue(1).ToString()
                                

                            };

                            context.Students.Add(st);
                            await context.SaveChangesAsync();
                        }
                    }
                }
                System.IO.File.Delete(filename);
                return "Success";
            }
            catch
            {
                if ((System.IO.File.Exists(filename)))
                {
                    System.IO.File.Delete(filename);
                }

                return "Failure";
            }

        }

        public async Task deletealldataindatabseQustions()
        {
            var records = context.QuestionPapers.ToList();
            if(records!=null)
            {
                foreach(var record in records)
                {
                    context.Remove(record);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task deletealldataindatabseStudents()
        {
            var records = context.Students.ToList();
            if (records != null)
            {
                foreach (var record in records)
                {
                    context.Remove(record);
                    await context.SaveChangesAsync();
                }
            }
        }

        public List<QuestionPaper> ExtractQuestions()
        {
            var records = context.QuestionPapers.ToList();
            return records;
        }

        public List<Student> ExtractStudents()
        {
            var records = context.Students.ToList();
            return records;
        }

        public async Task<List<Result>> ShowResult()
        {
            var res = await context.Results.ToListAsync();
            return res;
        }

        public async Task Delete(int id)
        {
            var res = await context.Results.FindAsync(id);
            context.Remove(res);
            await context.SaveChangesAsync();
            Email ec = new Email()
            {
                to = res.Username, 
                body = "You got another chance to give exam. \n Please click on this link " + "https://localhost:44316/GetQuestion/Index" + " to proceed",
                subject = "Reexam for " + res.Username
            };
            try
            {
                EmailSend(ec);
            }
            catch
            {

            }
        }

        public async Task<List<Result>> GetResults()
        {
            var results = await context.Results.ToListAsync();
            return results;
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


