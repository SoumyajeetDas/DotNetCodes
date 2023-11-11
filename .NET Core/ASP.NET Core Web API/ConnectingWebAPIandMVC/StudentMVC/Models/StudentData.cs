using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVC.Models
{
    public class StudentData
    { 
        [Required]
        public int Id { set; get; }
        [Required(ErrorMessage ="Enter the name")]
        [DataType(DataType.Text)]
        public string Name { set; get; }
    }
}
