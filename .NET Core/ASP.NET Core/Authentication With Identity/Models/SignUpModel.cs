using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_With_Identity.Models
{
    public class SignUpModel
    {
        [Required]
        public string UserName { set; get; }
        [Required]
        [EmailAddress]
        public string Email { set; get; }
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { set; get; }
        [Required]
        public string ConfirmPassword { set; get; }
    }
}
