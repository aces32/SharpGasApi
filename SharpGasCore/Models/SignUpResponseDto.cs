using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGasCore.Models
{
    /// <summary>
    /// signup response model
    /// </summary>
    public class SignUpResponseDto
    {
        /// <summary>
        /// Auto generated customer id for succesfully signed up customer
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// firstname indicated by the customer signing up
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName indicated by the customer signing up
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Username indicated by the customer signing up
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// MobileNumber indicated by the customer signing up
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// EmailAddress indicated by the customer signing up
        /// </summary>
        public string EmailAddress { get; set; }
    }
}
