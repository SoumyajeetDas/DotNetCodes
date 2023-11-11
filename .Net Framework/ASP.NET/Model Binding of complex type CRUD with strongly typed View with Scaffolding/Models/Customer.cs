using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1_Model_Binding_CRUD.Models
{
    public class Customer
    {
        public int CustCode
        {
            set;get;
        }

        public string CustName
        {
            set;get;
        }
        public string CustCity
        {
            set;get;
        }
    }
}