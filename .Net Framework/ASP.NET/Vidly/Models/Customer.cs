using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the Name")]
        public string Name { get; set; }

        
        [Display(Name="Birth Date")]
        [DataType(DataType.Date)]
        [Minimum18Years]
        public DateTime BirthDate { set; get; }

        public bool IsSubscribedToNewsletter { set; get; }

        [ForeignKey("MembershipType")]
        public int MembershipTypeId { set; get; }

        public MembershipType MembershipType { set; get; }
    }
}