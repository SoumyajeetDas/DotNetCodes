using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstMVCPractise.Models
{
    public class User
    {
        [Key]
        public int UserId { set; get; }

        [Required(ErrorMessage ="Enter the Name")]
        public string Name { set; get; }

        [Required(ErrorMessage ="Enter the Address")]
        public string Address { set; get; }

        [Required(ErrorMessage ="Enter the Contact No")]
        [Display(Name="Contact No.")]
        public string Contact { set; get; }
    }
}