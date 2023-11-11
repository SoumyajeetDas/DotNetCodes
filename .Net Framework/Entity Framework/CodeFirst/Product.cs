using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst
{
    //POCO class
    class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Prod_Id
        {
            set;get;
        }
        [Required]
        public string Prod_Name
        {
            set;get;
        }

        [Required]
        public string Prod_Type
        {
            set;get;
        }

        [ForeignKey ("Supplier")]
        public int Sup_Id
        {
            set;get;
        }
        [ForeignKey("Category")]
        public int Cat_Id
        {
            set;get;
        }
        public virtual Supplier Supplier { set; get; }
        public virtual Category Category { set; get; }

    }
}
