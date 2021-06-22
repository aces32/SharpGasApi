using SharpGasData.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharpGasData.Entities
{
    public partial class CustomerOrders
    {
        [Key]
        public int CustomerOrdersID { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public Customers Customers { get; set; }
        [ForeignKey("GasInformation")]
        public int GasId { get; set; }
        public GasInformation GasInformation { get; set; }

    }
}
