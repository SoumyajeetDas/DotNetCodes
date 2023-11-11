using HandleErrorCheck.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandleErrorCheck.Controllers
{
    //[HandleError]
    [MyException]
    public class SimpleController : Controller
    {
        // GET: Simple

        [Route("SimpleIndex")]

        [HandleError]

        public ActionResult Index()
        {
            throw new Exception("OOps Something Went Wrong");
        }

        [Route("SimpleIndex1")]
        //[MyException]
        public ActionResult Index1()
        {
            return View();
        }
    }
}