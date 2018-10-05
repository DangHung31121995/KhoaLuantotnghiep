using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Core.Model
{
    [Table("Footers")]
    public class Footer
    {
        public string ID { get; set; }
        [Required]
        public string Content { get; set; }              
    }
}
