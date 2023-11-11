using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnitityFrameworkWithASP.NETCore.Models
{
    public class BookModel
    {
        [Display(Name ="Book Id")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            set;get;
        }

        [Required(ErrorMessage ="Please enter the Title")]
        [Display(Name ="Book Title")]
        [StringLength(30,MinimumLength =4,ErrorMessage ="Length should be between 4 and 30")]
        public string Title
        {
            set;get;
        }

        [Required(ErrorMessage ="Please enter the Author")]
        [Display(Name="Book Author")]
        [RegularExpression(@"[a-zA-Z].[a-zA-Z]+",ErrorMessage = "The pattern is [a-zA-Z].[a-zA-Z]+")]
        public string Author
        {
            set;get;
        }

        [Required(ErrorMessage = "Please enter the Description")]
        [Display(Name = "Book Description")]
        public string Description
        {
            set;get;
        }

        [Required(ErrorMessage = "Please give the DateTime")]
        [DataType(DataType.DateTime,ErrorMessage ="Please enter DateTime")]
        [Display(Name ="Created On")]
        public DateTime CreatedOn
        {
            set;get;
        }
    }
}
