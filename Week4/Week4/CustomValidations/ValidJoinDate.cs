using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Week4.CustomValidations
{
    public class ValidJoinDate: ValidationAttribute
    {
        /*public ValidJoinDate(): base("{0} Join date cannot be in the future.")
        {

        }*/
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(value);
            if (date > DateTime.Now)
            {
                //var Error_Message = FormatErrorMessage(base.ErrorMessage);
                return new ValidationResult("Join date cannot be in the future.");
            }
            return ValidationResult.Success;
        }
    }
}