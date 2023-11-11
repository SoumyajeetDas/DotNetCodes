using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebAPI.Models.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Enter the Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter the Password")]
        public string Password { get; set; }

        public string Role { set; get; }
    }
}
