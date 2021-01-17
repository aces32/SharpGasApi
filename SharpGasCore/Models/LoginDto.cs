using SharpGasCore.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharpGasCore.Models
{
    /// <summary>
    /// Login request model
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// Users email address (encrypted)
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [Encrypted(ErrorMessage = "Ensure Email Address is encrypted")]
        [ValidEmailAddress(ErrorMessage = "Invalid Email Address Format")]
        public string Email { get; set; }

        /// <summary>
        /// Users password loggin in (encrypted)
        /// </summary>
        [Required(ErrorMessage = "PassWord is required")]
        [Encrypted(ErrorMessage = "Ensure PassWord is encrypted")]
        public string Password { get; set; }
    }
}
