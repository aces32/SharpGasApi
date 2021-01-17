using SharpGasCore.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharpGasCore.Models
{
    /// <summary>
    /// GAS request model
    /// </summary>
    public class GasRecords
    {
        /// <summary>
        /// Gas weight gotten from the microcontroller
        /// </summary>
        [Required(ErrorMessage = "GasWeight is required")]
        public double GasWeight { get; set; }
        /// <summary>
        /// Gas mobile number (Which Serves as gas Identifier) (encrypted)
        /// </summary>
        [Required(ErrorMessage = "GasMobileNumber is required")]
        //[Encrypted(ErrorMessage = "Ensure Gas mobile number is encrypted")]
        //[ValidMobileNumber(ErrorMessage = "Invalid Mobile Number Format")]
        public string GasMobileNumber { get; set; }

    }
}
