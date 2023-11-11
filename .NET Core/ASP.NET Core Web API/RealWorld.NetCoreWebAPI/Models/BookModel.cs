using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealWorld.NetCoreWebAPI.Models
{
    public class BookModel
    {
        public int Id
        {
            set; get;
        }
        public string Title
        {
            set; get;
        }
        public string Description
        {
            set; get;
        }
    }
}
