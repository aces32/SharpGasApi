using SharpGasCore.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace SharpGasCore.ValidationAttributes
{
    public class ValidMobileNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
        ValidationContext validationContext)
        {
            string decryptedVal = DecryptionUtil.RSADecrypt(value.ToString());
            if (string.IsNullOrEmpty(decryptedVal))
            {
                return new ValidationResult(FormatErrorMessage("Make sure your Mobile Numbefr is encrypted"));
            }
            var mobileNumber = (string)decryptedVal;
            string MatchPhoneNumberPattern = @"\s*(?:\+?(\d{1,3}))?([-. (]*(\d{3})[-. )]*)?((\d{3})[-. ]*(\d{2,4})(?:[-.x ]*(\d+))?)\s*";

            if (!Regex.IsMatch(mobileNumber, MatchPhoneNumberPattern))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
