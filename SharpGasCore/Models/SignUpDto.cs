using SharpGasCore.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharpGasCore.Models
{
    public class SignUpDto
    {
        [Required(ErrorMessage = "Firstname is required")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [ValidEmailAddress(ErrorMessage = "Invalid Email Address Format")]
        public string email { get; set; }

        [Required(ErrorMessage = "mobileNumber is required")]
        [ValidMobileNumber(ErrorMessage = "Invalid Mobile Number Format")]
        public string mobileNumber { get; set; }

        [Required(ErrorMessage = "passWord is required")]
        public string password { get; set; }
    }
}
