using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { set; get; }

        [Required]
        public string Username { set; get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}
