using SharpGasData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharpGasData.Services
{
    public interface IEncryptionKeyRepository
    {
        List<EncryptionKeys> EncryptionKeys();
    }
}
