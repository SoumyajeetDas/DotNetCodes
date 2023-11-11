using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Models.DTOs
{
    public class AdminDto
    {
       
        public string Username { set; get; }

        public string Password { set; get; }

        public string Role { set; get; }

        public string Token { set; get; }
    }
}
