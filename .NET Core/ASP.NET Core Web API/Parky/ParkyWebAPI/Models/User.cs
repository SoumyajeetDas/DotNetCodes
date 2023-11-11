using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter the Username")]
        public string UserName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Enter the Password")]
        public string Password { get; set; } = String.Empty;

        public string Role { set; get; } = String.Empty;

        [NotMapped]
        public string Token { set; get; } = String.Empty;
    }
}
