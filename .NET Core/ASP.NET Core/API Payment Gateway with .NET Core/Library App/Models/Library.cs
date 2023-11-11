using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Models
{
    public class Library
    {
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage ="Enter the book name")]
        [Display(Name = "Book Name")]
        public string BookName { set; get; }

        [Required(ErrorMessage = "Enter the Author name")]
        [Display(Name = "Author Name")]
        public string AuthorName { set; get; }

        [Display(Name = "Description")]
        public string Details { set; get; }

        [Display(Name ="Image")]
        public byte[] Picture { set; get; }

        [Display(Name ="Price")]
        [Required(ErrorMessage ="Enter the cost")]
        public double cost { set; get; }
    }
}
