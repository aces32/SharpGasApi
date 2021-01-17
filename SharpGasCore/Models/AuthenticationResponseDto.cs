using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGasCore.Models
{
    public class AuthenticationResponseDto
    {
        public string BearerToken { get; set; }
        public DateTime? ExpiryPeriod { get; set; }
    }
}
