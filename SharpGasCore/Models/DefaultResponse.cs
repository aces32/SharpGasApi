using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGasCore.Models
{
    public class DefaultResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
