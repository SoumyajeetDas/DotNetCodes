using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnitityFrameworkWithASP.NETCore.Data
{
    public class Books
    {
        public int Id
        {
            set; get;
        }
        public string Title
        {
            set; get;
        }
        public string Author
        {
            set; get;
        }
        public string Description
        {
            set; get;
        }
        public DateTime CreatedOn
        {
            set; get;
        }
    }
}
