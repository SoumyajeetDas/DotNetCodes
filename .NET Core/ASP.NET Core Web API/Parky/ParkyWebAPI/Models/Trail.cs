using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebAPI.Models
{
    public enum DifficultyType { Easy,Moderate,Difficult,Expert };
    public class Trail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Distance { set; get; }

        [Required]
        public DifficultyType Difficulty { set; get; }

        [Required]
        public int NationalParkId { set; get; }

        [ForeignKey("NationalParkId")]
        public NationalPark NationalPark { set; get; }

        public DateTime DataCreated { set; get; }
    }
}
