
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace Vidly.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public string GenreName { get; set; }   
    }
}