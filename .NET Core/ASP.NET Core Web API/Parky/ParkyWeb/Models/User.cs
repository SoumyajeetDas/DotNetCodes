using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWeb.Models
{
    public class User
    {
        
        
        [Required(ErrorMessage = "Enter the Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter the Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { set; get; }

        
        public string Token { set; get; }
    }
}
