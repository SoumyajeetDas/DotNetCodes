using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebAPI.Models.DTOs
{
    public class NationalParkDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the State")]
        public string State { get; set; }
        public DateTime Created { get; set; }
        public byte[] Picture { get; set; }
        public DateTime Established { get; set; }
    }
}
