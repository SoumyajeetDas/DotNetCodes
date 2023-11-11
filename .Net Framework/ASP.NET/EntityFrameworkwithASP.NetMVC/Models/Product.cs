using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityFrameworkwithASP.NetMVC.Models
{
    public class Product
    {
        [DisplayName("Product Id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Prod_Id
        {
            set; get;
        }
        [DisplayName("Product Name")]
        [Required(ErrorMessage ="Please enter the Product Name e.g. Laptop")]
        public string Prod_Name
        {
            set; get;
        }

        [DisplayName("Product Type")]
        [Required(ErrorMessage ="Please enter the Product Type e.g. Electronics")]
        public string Prod_Type
        {
            set; get;
        }

        [DisplayName("Product Price")]
        [Required(ErrorMessage ="Please enter the product price")]
        public double Prod_price
        {
            set;get;
        }

        //[Key]
        [Required]
        [DisplayName("Supplier Id")]
        [ForeignKey("Supplier")]
        public int Sup_Id
        {
            set;get;
        }

        [Required]
        [DisplayName("Category Id")]
        [ForeignKey("Category")]
        public int Cat_Id
        {
            set;get;
        }

        public virtual Supplier Supplier { set; get; }
        public virtual Category Category { set; get; }
    }
}