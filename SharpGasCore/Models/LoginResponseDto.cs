using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGasCore.Models
{
    /// <summary>
    /// Loginresponse model
    /// </summary>
    public class LoginResponseDto
    {
        /// <summary>
        /// Users generated customerID
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// users firstname used to signup
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// users LastName used to signup
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// users UserName used to signup
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// users MobileNumber used to signup
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// users EmailAddress used to signup
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// users Country used to signup
        /// </summary>
        public string Country { get; set; }
    }
}
