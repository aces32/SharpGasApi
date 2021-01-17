using SharpGasCore.Helpers;
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
            string decryptedVal = DecryptionUtil.RSADecrypt(value.ToString());
            if (string.IsNullOrEmpty(decryptedVal))
            {
                return new ValidationResult(FormatErrorMessage("Make sure your email address is encrypted"));
            }
            var emailAddress = (string)decryptedVal;
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
