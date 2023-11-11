using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWeb.Models
{
    public enum DifficultyType { Easy, Moderate, Difficult, Expert };
    public class Trail
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter the name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter the distance")]
        public double Distance { set; get; }

        public DifficultyType Difficulty { set; get; }

        [Required]
        [Display(Name="National Park Name")]
        public int NationalParkId { set; get; }

        public NationalPark NationalPark { set; get; }
    }
}
