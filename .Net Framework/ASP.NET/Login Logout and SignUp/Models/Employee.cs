using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Login_Logout_and_SignUp.Models
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id
        {
            set; get;
        }
        [Required(ErrorMessage = "Please enter the name")]
        [Display(Name = "Emp_Name")]
        public string Name
        {
            set; get;
        }
        [Required(ErrorMessage = "Please enter the Designation")]
        public string Designation
        {
            set; get;
        }
        [Required(ErrorMessage = "Please enter the salary")]
        public int Salary
        {
            set; get;
        }
    }
}