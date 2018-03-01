using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks; 

namespace TheVault.Configuration
{
    public class PaymentSettings
    {
        public string SecretKey { get; set; }
        public string PublishableKey { get; set; }
    }
}