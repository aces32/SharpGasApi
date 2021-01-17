using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharpGasData.Entities
{
    public class AuthCredentials
    {
        [Key]
        public int AuthID { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public int expiryLength { get; set; }
        public int Roles { get; set; }
    }
}
