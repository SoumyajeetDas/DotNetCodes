using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ValidationCheck.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Employee
    {
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(3)]
        //[Required]
        public string E_name
        {
            set;get;
        }
        [Required]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email
        {
            set;get;
        }
        [Required]
        [Range(18,100)]
        public int Age
        {
            set;get;
        }

        [Required(ErrorMessage ="Enter a gender")]
        [Range(1,2,ErrorMessage ="Check the range")] // Every Data Annotation have a Error Message
        public Gender Gender
        {
            set;get;
        }


    }
}