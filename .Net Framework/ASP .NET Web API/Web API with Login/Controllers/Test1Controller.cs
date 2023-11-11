using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_API_with_Login.Controllers
{
    public class Test1Controller : ApiController
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        [HttpGet]
        public IHttpActionResult Value1()
        {

            _logger.Info("Successful from second Test");
            return Ok("Successful");
            ;
        }
    }
}
