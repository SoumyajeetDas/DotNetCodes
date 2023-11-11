using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_With_Identity.Models
{
    public class Employee
    {
        [Required]
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public int Salary { set; get; }
    }
}
