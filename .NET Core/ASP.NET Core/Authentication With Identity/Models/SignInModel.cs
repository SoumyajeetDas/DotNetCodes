using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_With_Identity.Models
{
    public class SignInModel
    {
        [Required]
        public string UserName
        {
            set; get;
        }

        [Required]
        public string Password
        {
            set; get;
        }
    }
}
