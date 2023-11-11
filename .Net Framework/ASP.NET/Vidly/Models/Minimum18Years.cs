using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Minimum18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //validationContext.ObjectInstance basiaclly holds the object at 
            // first. Here it takes into customer and then we have to cast 
            //into the type we want.

            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("Birth Date is required");

            var age = DateTime.Now.Year - customer.BirthDate.Year;


            return (age > 18) ? ValidationResult.Success : 
                new ValidationResult("Age should be above 18 years");
        }
    }
}