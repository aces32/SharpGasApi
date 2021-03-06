﻿using System;
using System.Collections.Generic;

namespace SharpGasData.Entites
{
    public partial class Customers
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Password { get; set; }

        public List<GasInformation> GasID { get; set; }
    }
}
