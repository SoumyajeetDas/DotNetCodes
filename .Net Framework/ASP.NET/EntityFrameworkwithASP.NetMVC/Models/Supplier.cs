using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkwithASP.NetMVC.Models
{
    public class Supplier
    {
        [DisplayName("Supplier Id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sup_id
        {
            set; get;
        }


        [DisplayName("Supplier Name")]
        [Required(ErrorMessage = "Please enter the name the limit should be from 4 to 30")]
        [StringLength(30, MinimumLength = 4)]
        [RegularExpression(@"[a-zA-Z]{4,30}")]
        public string Sup_name
        {
            set; get;
        }


        [DisplayName("Supplier Phno.")]
        [RegularExpression(@"^[789][0-9]{9}$")]// If you give required functionality with RegularExpression it throw error as Regular Expression itself does thet work
        public string Sup_phno
        {
            set; get;
        }

        public virtual ICollection<Product> Products { set; get; }
    }
}