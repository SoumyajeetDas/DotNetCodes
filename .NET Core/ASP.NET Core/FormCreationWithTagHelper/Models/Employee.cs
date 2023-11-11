using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormCreationWithTagHelper.Models
{
    public enum Languages
    {
        [Display(Name = "Hindi Language")]
        Hindi,
        [Display(Name ="Bengali Language")]
        Bengali,
        [Display(Name ="English Language")]
        English
    }
    public class Employee
    {
        [Display(Name = "Employee Name")]
        public string Name
        {
            set;get;
        }

        [Display(Name="Employee Passwprd")]
        [DataType(DataType.Password)]
        public string Password
        {
            set;get;
        }

        
        [Display(Name="Emplyee Email Id")]
        [EmailAddress]
        public string Email
        {
            set;get;
        }


        [Display(Name="Employee Age")]
        public int Age
        {
            set;get;
        }

       
        [Display(Name = "Employee Language")]
        public Languages Languages
        { 
            set; 
            get; 
        }


        public bool Veg 
        { 
            set; 
            get; 
        }
        public bool NonVeg 
        { 
            set; 
            get; 
        }


        public string Description
        {
            set;get;
        }


        public string Gender
        {
            set;get;
        }
    }
}
