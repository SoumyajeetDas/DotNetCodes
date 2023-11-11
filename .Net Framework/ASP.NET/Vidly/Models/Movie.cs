using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter the Movie name")]
        [StringLength(maximumLength:200,MinimumLength =2,ErrorMessage ="Enter the Movie name b/w length 2 and 200")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter the Release Date")]
        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name ="Number in Stock")]
        public int NumberinStock { set; get; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }    

        public Genre Genre { get; set; }
    }
}