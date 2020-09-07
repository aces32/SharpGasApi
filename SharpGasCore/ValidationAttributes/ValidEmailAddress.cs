using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace SharpGasCore.ValidationAttributes
{
    public class ValidEmailAddress : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var emailAddress = (string)value;
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (!string.IsNullOrEmpty(emailAddress))
            {
                if (Regex.IsMatch(emailAddress, expression))
                {
                    if (Regex.Replace(emailAddress, expression, string.Empty).Length == 0)
                    {
                        return ValidationResult.Success;
                    }
                }
            }

            return new ValidationResult(ErrorMessage);

        }
    }
}
