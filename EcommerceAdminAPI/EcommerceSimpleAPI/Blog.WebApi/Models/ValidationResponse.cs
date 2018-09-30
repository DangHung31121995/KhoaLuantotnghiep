using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.Models
{
    public class ValidationResponse
    {
        public string Key { get; set; }
        public List<string> Validations { get; set; }
    }
}
