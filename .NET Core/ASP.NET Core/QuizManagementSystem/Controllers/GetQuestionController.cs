using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizManagementSystem.Models;
using QuizManagementSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QuizManagementSystem.Controllers
{
    [Authorize(Roles = "Student")]
    public class GetQuestionController : Controller
    {
        static int count = 0;
        static int? time;
        static List<string> CorectResultActual = new List<string>();
        static List<string> ResultGot = new List<string>();
        private IStudentQuestionRepository studentQuestionRepository;

        public GetQuestionController(IStudentQuestionRepository studentQuestionRepository)
        {
            this.studentQuestionRepository = studentQuestionRepository;
        }


        public async Task<IActionResult> Index()
        {

            var qp = await studentQuestionRepository.GetQuestions();
            ViewBag.Time = qp[0].Time;
            ViewBag.Count = qp.Count();

            var name = User.Identity.Name;

            ViewBag.Name = name;
           
            return View();
        }

        public async Task<IActionResult> ShowQuestion()
        {
            var name = User.Identity.Name;
            var check = await studentQuestionRepository.CheckUser(name);
            

            if(check==true)
            {
                return RedirectToAction("RedirectingUser");
            }
            var qp = await studentQuestionRepository.GetQuestions();


            if (count == 0)
            {
                time = qp[0].Time;
                foreach (var record in qp)
                {
                    CorectResultActual.Add(record.CorrectResult);
                }
            }

            var n = qp.Count();
            if (count == n)
            {
                count = 0;
                return RedirectToAction("ShowResult");
            }
            ViewBag.Question = qp[count].Question;
            ViewBag.FirstOption = qp[count].FirstOption;
            ViewBag.SecondOption = qp[count].SecondOption;
            ViewBag.ThirdOption = qp[count].ThirdOption;
            ViewBag.FourthOption = qp[count].FourthOption;
            count++;
            ViewBag.Count = count;
            ViewBag.Time = time;
            return View();
        }

        [HttpPost]
        public IActionResult ShowQuestion1(Answer answers)
        {
            ResultGot.Add(answers.answer);;
           
            return RedirectToAction("ShowQuestion");
        }

       
        public async Task<IActionResult> ShowResult()
        {
            int marks = 0;

            for (int i = 0; i < CorectResultActual.Count; i++)
            {
                try
                {
                    if (CorectResultActual[i] == ResultGot[i])
                    {
                        marks += 1;
                    }
                }
                catch
                {

                }

            }

            var qp = await studentQuestionRepository.GetQuestions();
            var d = marks / (qp.Count * 1.0);

            var percentage = Math.Round(d * 100.0, 2);

            var name = User.Identity.Name;
            var Status = await studentQuestionRepository.UploadResult(name, percentage);

            CorectResultActual.Clear();
            ResultGot.Clear();

            if (Status=="Success")
            {
                
                ViewBag.Success = Status;
                ViewBag.Result = percentage;

            }
            else
            {
                ViewBag.Failure = Status;
                
                
            }
            
            return View();
        }

        
        public IActionResult RedirectingUser()
        {
            return View();
        }

        

    }
}
