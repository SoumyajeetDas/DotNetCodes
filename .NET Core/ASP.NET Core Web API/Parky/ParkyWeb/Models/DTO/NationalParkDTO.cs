using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWeb.Models.DTO
{
    public class NationalParkDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the State")]
        public string State { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Created { get; set; }

        [DataType(DataType.Upload)]
        public IFormCollection Picture { set; get; }

        [DataType(DataType.DateTime)]
        public DateTime? Established { get; set; }
    }
}
