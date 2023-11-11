using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoutingCheck.Models
{
    public class Student
    {
        public int Id
        {
            set;get;
        }

        public string Name
        {
            set;get;
        }

        public Address Address
        {
            set;get;
        }
    }
}