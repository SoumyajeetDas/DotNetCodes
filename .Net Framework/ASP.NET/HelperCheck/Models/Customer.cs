using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelperCheck.Models
{
    public enum City
    {
        Kolkata,
        Bangalore,
        Delhi
    }
    public class Customer
    {
        
        public string Cus_Name
        {
            set; get;
        }

        public string Cus_Phone
        {
            set; get;
        }

        public string Password
        {
            set;get;
        }
        public bool New_To_Company
        {
            set; get;
        }
        public string Gender
        {
            set;get;
        }

        public City City
        {
            set;get;
        }
    }
}