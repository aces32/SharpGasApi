using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGasCore.Models
{
    public class VendorsResponseDto
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string VendorCountry { get; set; }
        public string VendorState { get; set; }
        public string VendorLGA { get; set; }
        public string VendorEmail { get; set; }
        public string VendorMobileNo { get; set; }
    }
}
