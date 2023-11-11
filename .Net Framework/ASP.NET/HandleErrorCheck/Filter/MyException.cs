using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandleErrorCheck.Filter
{
    public class MyException : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filtercontext)
        {
            filtercontext.Result = new ViewResult()
            {
                ViewName = "Error2"
            };

            filtercontext.ExceptionHandled = true;

        }
    }
}