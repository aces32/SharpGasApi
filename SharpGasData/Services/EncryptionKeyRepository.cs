using Microsoft.EntityFrameworkCore;
using SharpGasData.Entities;
using SharpGasData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGasData.Services
{
    public class EncryptionKeyRepository : IEncryptionKeyRepository
    {
        private readonly SharpGasContext sharpGasContext;

        public EncryptionKeyRepository(SharpGasContext sharpGasContext)
        {
            this.sharpGasContext = sharpGasContext;
        }
        public List<EncryptionKeys> EncryptionKeys()
        {
            return sharpGasContext.EncryptionKeys.ToList();
        }
    }
}
