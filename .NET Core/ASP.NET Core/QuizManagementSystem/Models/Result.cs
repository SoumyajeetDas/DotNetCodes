using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Models
{
    public class Result
    {
        [Key]
        public int Id { set; get; }

        [Required]
        public string Username { set; get; }

        [Required]
        [Display(Name ="Percentage")]
        public double percentage { set; get; }
    }
}
