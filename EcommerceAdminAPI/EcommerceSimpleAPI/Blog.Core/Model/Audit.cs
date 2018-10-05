using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Core.Model
{
    [Table("Audits")]
    public class Audit : IEntityBase
    {
        public string Content { get; set; }
        public string Level { get; set; }
    }
}
