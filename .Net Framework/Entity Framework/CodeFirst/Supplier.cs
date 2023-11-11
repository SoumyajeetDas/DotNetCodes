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
    class Supplier
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Primary Key with identity --> Here in identity you cannot specify from where to start 
        //[Key] --> Primary Key without identity

        public int Sup_id
        {
            set;get;
        }


        [Required] // To specify not null
        [StringLength(30,MinimumLength =8)] // [StringLength(MaxLength,MinimumLength= )] StringLength sets the value in DB like nvarchar(50)
        [RegularExpression(@"^[A-Za-z]{3,10}$")]
        public string Sup_name
        {
            set;get;
        }



        [RegularExpression(@"^[789][0-9]{9}$")]
        public long Sup_phno
        {
            set;get;
        }



        public virtual ICollection<Product>Products
        {
            set;get;
        }


    }
}
