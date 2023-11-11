using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using QuizManagementSystem.Models;
using QuizManagementSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Controllers
{
   
    public class UploadFileController : Controller
    {
        
        static int? time;

       
        private IAdminUploadFileRepository adminUploadFileRepository;
        public UploadFileController(IAdminUploadFileRepository adminUploadFileRepository)
        {
            this.adminUploadFileRepository = adminUploadFileRepository;
        }
        public IActionResult UploadFile()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "AdminAccount");
            }

            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(UploadFile uploadFile)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            time = uploadFile.Time;
            var codeQuestions = await adminUploadFileRepository.UploadQuestionPaper(uploadFile.QsFile,time); //GetQuestionList will extract the list of entries in the file and will convert in to List<Student>
            var codeStudents = await adminUploadFileRepository.UploadStudentList(uploadFile.StuFile); 
            //time = uploadFile.Time;
            ViewBag.StatusQuestions = codeQuestions;
            ViewBag.StatusStudents = codeStudents;
            var qp = adminUploadFileRepository.ExtractQuestions();
            var st = adminUploadFileRepository.ExtractStudents();
            ViewBag.Questions = qp;
            ViewBag.Students = st;

            return View();
        }

        public async Task<IActionResult> ShowResults()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "AdminAccount");
            }

            var res = await adminUploadFileRepository.ShowResult();

            return View(res);
        }

        public async Task<IActionResult> ExcelDownload()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "AdminAccount");
            }
            var results = await adminUploadFileRepository.GetResults();
            var stream = new MemoryStream();


            using (var xlpackage = new ExcelPackage(stream))
            {
                var worksheet = xlpackage.Workbook.Worksheets.Add("results");

                var startrow = 4;
                var row = startrow;

                worksheet.Cells["A1"].Value = "Student List";

                using (var r = worksheet.Cells["A1:C1"])
                {
                    r.Merge = true;
                    r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    r.Style.Font.Color.SetColor(color: System.Drawing.Color.Yellow);
                    r.Style.Fill.BackgroundColor.SetColor(color: System.Drawing.Color.Black);
                }

                worksheet.Cells["A3"].Value = "Id";
                worksheet.Cells["B3"].Value = "Username";
                worksheet.Cells["C3"].Value = "Marks";
                worksheet.Cells["A3:C3"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells["A3:C3"].Style.Font.Color.SetColor(color: System.Drawing.Color.White);
                worksheet.Cells["A3:C3"].Style.Fill.BackgroundColor.SetColor(color: System.Drawing.Color.Black);

                int j = 0;
                foreach (var res in results)
                {
                    j++;
                    worksheet.Cells[row, 1].Value = j;
                    worksheet.Cells[row, 2].Value = res.Username;
                    worksheet.Cells[row, 3].Value = res.percentage + " %";
                    row++;
                }

                xlpackage.Save();

            }
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "result.xlsx");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "AdminAccount");
            }
            await adminUploadFileRepository.Delete(id);
            return RedirectToAction("ShowResults");
        }
    }
}
