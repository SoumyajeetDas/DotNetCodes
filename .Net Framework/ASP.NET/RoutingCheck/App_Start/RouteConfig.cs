using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoutingCheck
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //        name: "allStudents",
            //        url: "Students",
            //        defaults: new { controller = "Simple", action = "GetAllStudents" }
            //    );
            routes.MapRoute(
                    name: "studentbyid",
                    url: "StudentId/{id}",
                    defaults: new { controller = "Simple", action = "GetStudent", id = 1 },
                    constraints: new { id = @"\d+" }
                );
            routes.MapRoute(
                    name: "studentbystringid",
                    url: "StudentId/{id}",
                    defaults: new { controller = "Simple", action = "MyString", id = "Soumyajeet" },
                    constraints: new { id = @"\D+" }
                );
            //routes.MapRoute(
            //        name: "studentaddress",
            //        url: "StudentAddress/{ids}/Address",
            //        defaults: new { controller = "Simple", action = "GetStudentAddress", ids = 1 },
            //        constraints: new { ids = @"\d+" }
            //    );

            //routes.MapRoute(
            //        name: "studentaddress1",
            //        url: "StudentAddress/{ids}",
            //        defaults: new { controller = "Simple", action = "GetStudentAddress", ids = 1 },
            //        constraints: new { ids = @"\d+" }
            //    );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
