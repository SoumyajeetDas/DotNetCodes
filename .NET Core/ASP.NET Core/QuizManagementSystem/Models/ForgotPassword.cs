using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManagementSystem.Models
{
    public class ForgotPassword
    {
        [Required(ErrorMessage ="Enter the email address")]
        [DataType(DataType.EmailAddress)]
        public string Username
        {
            set;get;
        }

        [Required(ErrorMessage ="Enter the Password")]
        [DataType(DataType.Password)]
        public string Password
        {
            set;get;
        }

        [Required(ErrorMessage ="Enter the Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password didn't match")]
        public string ConfirmNewPassord
        {
            set;get;
        }

    }
}
