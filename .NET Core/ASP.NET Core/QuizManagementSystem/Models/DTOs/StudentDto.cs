using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Models.DTOs
{
    public class StudentDto
    {
        public string Username { set; get; }

        public string Password { set; get; }

        public string Role { set; get; }

        public string Token { set; get; }
    }
}
