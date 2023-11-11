using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstAPIPractise.Models
{
    public class User
    {
        [Key]
        public int UserId { set; get; }
        
        [Required(ErrorMessage ="Enter the User Name")]
        public string Name { set; get; }

        [Required(ErrorMessage ="Enter the Address")]
        public string Address { set; get; }

        [Required(ErrorMessage ="Enter the Contact No.")]
        public string Contact { set; get; }
    }
}