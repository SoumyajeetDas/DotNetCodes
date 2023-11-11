using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Models
{
    public class Admin
    {
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Please enter the Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Username { set; get; }

        [Required(ErrorMessage = "Please enter the Password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        
        public string Role { set; get; }

    }
}
