using SharpGasCore.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharpGasCore.Models
{
    public class GasRecords
    {

        [Required(ErrorMessage = "GasWeight is required")]
        public double GasWeight { get; set; }

        [Required(ErrorMessage = "GasMobileNumber is required")]
        [ValidMobileNumber(ErrorMessage = "Invalid Mobile Number Format")]
        public string GasMobileNumber { get; set; }

    }
}
