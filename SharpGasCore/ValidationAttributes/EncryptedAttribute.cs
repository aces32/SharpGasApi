
using SharpGasCore.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharpGasCore.ValidationAttributes
{
    public class EncryptedAttribute : ValidationAttribute
    {
        public int MinStringLength { get; set; }
        public int MaxStringLength { get; set; }
        public string FieldName { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            try
            {

                if (string.IsNullOrEmpty(value.ToString()))
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }

                string decryptedVal = DecryptionUtil.RSADecrypt(value.ToString());
                if (string.IsNullOrEmpty(decryptedVal))
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
                if (MinStringLength != 0)
                {
                    if (decryptedVal.Length < MinStringLength)
                    {
                        return new ValidationResult($"{FieldName} must not be less than {MinStringLength} characters");
                    }
                }
                else if (MaxStringLength != 0)
                {
                    if (decryptedVal.Length > MaxStringLength)
                    {
                        return new ValidationResult($"{FieldName} Password cannot be greater than {MaxStringLength} characters");
                    }
                }

                validationContext
                .ObjectType
                .GetProperty(validationContext.MemberName)
                .SetValue(validationContext.ObjectInstance,
                decryptedVal,
                null);

                return ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
        }
    }
}
