using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    public class MenuViewModel
    {
        public IEnumerable<string> Adidas { get; set; }
        public IEnumerable<string> Jordans { get; set;}
        public IEnumerable<string> Nike { get; set; }
        public IEnumerable<string> Reebok { get; set; }
        public IEnumerable<string> UnderArmour { get; set; }
    }
}