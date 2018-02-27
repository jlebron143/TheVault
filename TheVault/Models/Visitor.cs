using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    public class Visitor
    {
        [Key]
        public int VisitorID { get; set; }
        public string ScreenName { get; set; }
        public string UserID { get; set;  }
    }
}