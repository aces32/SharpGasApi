using SharpGasData.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharpGasData.Entities
{
    public partial class VendorGasMap
    {
        [Key]
        public int VendorGasMapID { get; set; }
        [ForeignKey("Vendors")]
        public int VendorID { get; set; }
        public Vendors Vendors { get; set; }
        [ForeignKey("GasInformation")]
        public int GasId { get; set; }
        public GasInformation GasInformation { get; set; }
    }
}
