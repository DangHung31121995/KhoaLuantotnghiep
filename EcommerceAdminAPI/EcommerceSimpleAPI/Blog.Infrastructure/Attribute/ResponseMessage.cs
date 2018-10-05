using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Infrastructure.Enums;

namespace Ecommerce.Infrastructure.Attribute
{
    public class ResponseMessage
    {
        public string Key { get; set; }

        public string Message { get; set; }

        public QueryStatus Status { get; set; }
    }
}
