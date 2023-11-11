using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomActionFilter.Filter
{
    public class MyAction : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewData["Message"] = "Hi I am Soumyajeet"; // This will be added to the view before it is rendered
            Debug.WriteLine("Executing onActionExecuted");
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("Executing onActionExecuting");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debug.WriteLine("Executing onResultExecuted");
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Debug.WriteLine("Executing onResultExecuting");
        }
    }
}