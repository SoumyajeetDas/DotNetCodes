using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkwithASP.NetMVC.Models
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
        [Required(ErrorMessage ="Enter the category type")]
        public string Cat_Type
        {
            set; get;
        }
        public virtual ICollection<Product> Products { set; get; }
    }
}