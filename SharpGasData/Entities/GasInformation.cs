using System;
using System.Collections.Generic;

namespace SharpGasData.Entites
{
    public partial class GasInformation
    {
        public int GasId { get; set; }
        public string GasMobileNumber { get; set; }
        public int? CustomerId { get; set; }
        public double? GasWeight { get; set; }
    }
}
