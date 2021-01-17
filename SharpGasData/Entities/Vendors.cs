using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharpGasData.Entities
{
    public class Vendors
    {
        [Key]
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string VendorCountry { get; set; }
        public string VendorState { get; set; }
        public string VendorLGA { get; set; }
        public string VendorEmail { get; set; }
        public string VendorMobileNo { get; set; }
        public byte[] VendorPassword { get; set; }
        public string VendorType { get; set; }
    }
}
