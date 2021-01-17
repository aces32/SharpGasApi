using SharpGasCore.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SharpGas.Encryption
{
    public class UserCredentials
    {
        /// <summary>
        /// Username for authentication to generate token
        /// </summary>
        [Required(ErrorMessage = "Username is required")]
        [Encrypted(ErrorMessage = "Ensure Username is encrypted")]
        public string Username { get; set; }
        /// <summary>
        /// Username for authentication to generate token
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        [Encrypted(ErrorMessage = "Ensure Password is encrypted")]
        public string Password { get; set; }
    }
}
