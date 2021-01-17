using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpGas.Configuration
{
    /// <summary>
    /// Application configuration settings
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Encrption key
        /// </summary>
        public string EncryptionKey { get; set; }
        /// <summary>
        /// public key
        /// </summary>
        public string PUBLICXML { get; set; }
        /// <summary>
        /// Private key
        /// </summary>
        public string PRIVATEXML { get; set; }
        /// <summary>
        /// Path for the class libary sharpgas core documentation
        /// </summary>
        public string SharpGasCorePath { get; set; }
        /// <summary>
        /// Connection string for dapper connection
        /// </summary>
        public string SharpGasConnectionString { get; set; }

    }
}
