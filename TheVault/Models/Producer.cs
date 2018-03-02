using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    public class Producer
    {
        [Key]
        public int ProducerID { get; set; }
        public string Name { get; set; }
    }
}