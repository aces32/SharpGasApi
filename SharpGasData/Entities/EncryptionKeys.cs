using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharpGasData.Entities
{
    public class EncryptionKeys
    {
        [Key]
        public int KeyId { get; set; }
        public string PublicKey { get; set; }
        public string PublicKeyXML { get; set; }
        public string PrivateKey { get; set; }
        public string PrivateKeyXML { get; set; }
    }
}
