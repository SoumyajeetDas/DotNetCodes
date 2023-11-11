using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebAPI.Models.DTOs
{
    public class TrailInsertDTO
    {
       [Required]
        public string Name { get; set; }

        [Required]
        public double Distance { set; get; }

        public DifficultyType Difficulty { set; get; }

        [Required]
        public int NationalParkId { set; get; }

        
    }
}
