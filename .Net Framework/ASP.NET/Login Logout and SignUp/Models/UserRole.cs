using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Login_Logout_and_SignUp.Models
{
    public class UserRole
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRole_Id
        {
            set; get;
        }
        

        [Required(ErrorMessage = "Please provide the role")]
        public string Role
        {
            set; get;
        }
        [ForeignKey("User")]
        public int User_Id
        {
            set; get;
        }

        public virtual User User { set; get; }


    }
}