using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnitityFrameworkWithASP.NETCore.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("Error/{statuscode}")]
        public IActionResult HttpStatusCodeHandler(int statuscode)
        {
            logger.LogDebug("Entering into HttpStatus");
            switch(statuscode)
            {
                case 404:
                    ViewBag.ErrorMessaage = "Sorry Page cannot be found";
                    break;
            }
            return View();
        }

        [Route("Error/{statuscode?}")]
        public IActionResult EmployeeNotFound()
        {
            return View();
        }

        [Route("Error/Exception")]
        public IActionResult ErrorException()
        {
            logger.LogInformation("Entering into ErrorException");
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Path = exceptionHandlerPathFeature.Path;
            ViewBag.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;

            logger.LogWarning($"404 error occurred with path of {exceptionHandlerPathFeature.Path} and StackTrace of" +
                $"{exceptionHandlerPathFeature.Error.StackTrace}");
            return View();
        }

    }
}
