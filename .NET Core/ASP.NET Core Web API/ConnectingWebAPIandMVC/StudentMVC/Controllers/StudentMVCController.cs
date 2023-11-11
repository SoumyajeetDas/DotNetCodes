using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentMVC.Helper;
using StudentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace StudentMVC.Controllers
{
    
    public class StudentMVCController : Controller
    {
        
        StudentAPIData api = new StudentAPIData();

        
        public async Task<IActionResult> Index()
        {
            List<StudentData> data = new List<StudentData>();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Student/getallstudents"); //Sends the request to the given url and the  data is stored which is sent by the api.

            if(res.IsSuccessStatusCode)
            {
                
                //await res.Content.ReadAsStringAsync();
                var results = res.Content.ReadAsStringAsync().Result; // The main content part is stored in the results in the json format in the form of string
                data = JsonConvert.DeserializeObject<List<StudentData>>(results); //JsonConvert.DeserializeObject deserializes the JSon object to the List of type StudentData
            }

            client.Dispose();
            return View(data);
        }

       
        public async Task<IActionResult> GetStudentById(int id)
        {
            var data = new StudentData();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Student/getstudentid/"+id); //Sends the request to the given url and the  data is stored which is sent by the api.

            if (res.IsSuccessStatusCode)
            {

                //await res.Content.ReadAsStringAsync();
                var results = res.Content.ReadAsStringAsync().Result; // The main content part is stored in the results in the json format in the form of string
                data = JsonConvert.DeserializeObject<StudentData>(results); //JsonConvert.DeserializeObject deserializes the JSon object to the List of type StudentData
            }

            client.Dispose();
            return View(data);
        }

      
        public ViewResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(StudentData studentData)
        {

            HttpClient client = api.Initial();

            var postdata =  client.PostAsJsonAsync<StudentData>("api/Student/AddStudent",studentData);
            postdata.Wait();

            var result = postdata.Result;
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
