using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Attacker_Profile.Models
{
    public class Category
    {
        [DisplayName("Category Id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cat_Id
        {
            set; get;
        }

        [DisplayName("Category Type")]
        [Required(ErrorMessage = "Enter the category type")]
        public string Cat_Type
        {
            set; get;
        }
        
    }
}