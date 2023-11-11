using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Models.DTO
{
    public class LibrarySecuredDTO 
    {
        public int Id { set; get; }

        public string BookName { set; get; }

        public string AuthorName { set; get; }

        public string Details { set; get; }

        public byte[] Picture { set; get; }

        public double cost { set; get; }

        public string Nonce { get; set; }
    }
}
