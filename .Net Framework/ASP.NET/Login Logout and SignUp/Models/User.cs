using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Login_Logout_and_SignUp.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            set; get;
        }
        [Required(ErrorMessage = "Enter the Username")]
        public string Username
        {
            set; get;
        }
        [Required(ErrorMessage = "Enter the password")]
        public string Password
        {
            set; get;
        }

        [Required(ErrorMessage = "Enter the password")]
        [EmailAddress]
        public string Email
        {
            set; get;
        }
        [Required(ErrorMessage = "Please enter the role")]
        [Display(Name = "User Role")]
        public string Role
        {
            set; get;
        }

        public virtual ICollection<UserRole> UserRoles { set; get; }

    }
}