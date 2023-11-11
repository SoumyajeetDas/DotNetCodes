using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        [Key]
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public short SignUpFee { set; get; }

        [Required]
        public byte DurationInMonths { set; get; }

        [Required]
        public byte DiscountRate { set; get; }
    }
}