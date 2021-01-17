using SharpGasCore.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharpGasCore.Models
{
    /// <summary>
    /// signup request model
    /// </summary>
    public class SignUpDto
    {
        /// <summary>
        /// customers Firstname signing up (encrypted)
        /// </summary>
        [Required(ErrorMessage = "Firstname is required")]
        [Encrypted(ErrorMessage = "Ensure LastName is encrypted")]
        public string Firstname { get; set; }

        /// <summary>
        /// customers firstname signing up (encrypted)
        /// </summary>
        [Required(ErrorMessage = "Lastname is required")]
        [Encrypted(ErrorMessage = "Ensure LastName is encrypted")]
        public string LastName { get; set; }

        /// <summary>
        /// customers LastName signing up (encrypted)
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [ValidEmailAddress(ErrorMessage = "Invalid Email Address Format")]
        [Encrypted(ErrorMessage = "Ensure Email Address is encrypted")]
        public string Email { get; set; }

        /// <summary>
        /// customers MobileNumber signing up (encrypted)
        /// </summary>
        [Required(ErrorMessage = "mobileNumber is required")]
        [ValidMobileNumber(ErrorMessage = "Invalid Mobile Number Format")]
        [Encrypted(ErrorMessage = "Ensure MobileNumber is encrypted")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// customers Password signing up (encrypted)
        /// </summary>
        [Required(ErrorMessage = "passWord is required")]
        [Encrypted(ErrorMessage = "Ensure Password is encrypted")]
        public string Password { get; set; }
    }
}
