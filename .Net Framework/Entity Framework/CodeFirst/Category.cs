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
    class Category
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cat_Id
        {
            set;get;
        }
        [Required]
        public string Cat_Type
        {
            set;get;
        }
        public virtual ICollection<Product> Products { set; get; }
    }
}
