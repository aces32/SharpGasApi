using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGasCore.Models
{
    public class SignUpResponseDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ResponseDescription { get; set; }
    }
}
