using SharpGasCore.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharpGasCore.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [ValidEmailAddress(ErrorMessage = "Invalid Email Address Format")]
        public string email { get; set; }

        [Required(ErrorMessage = "PassWord is required")]
        public string password { get; set; }
    }
}
