using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWeb.Models
{
    public class NationalPark
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the State")]
        public string State { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Created { get; set; }

        public byte[] Picture { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Established { get; set; }
    }
}
