using SharpGasData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharpGasData.Entites
{
    public partial class GasInformation
    {
        [Key]
        public int GasId { get; set; }
        public string GasMobileNumber { get; set; }
        public double? GasWeight { get; set; }
        public int? Availability { get; set; }
        public double? Price { get; set; }
        public string GasImage { get; set; }
        public ICollection<CustomerOrders> CustomerOrders { get; set; }
        public ICollection<VendorGasMap> VendorGasMap { get; set; }

    }
}
