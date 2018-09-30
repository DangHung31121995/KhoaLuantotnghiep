using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Extensions
{
    public class EcommerceException : Exception
    {

        public EcommerceException(string message) : base(message) { }

        public EcommerceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
