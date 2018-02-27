using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    public class Size
    {
        [Key]
        [Display(Name = "Sizes")]
        public int SizeID { get; set; }
        [Display(Name = "Sizes") ]
        public string Sizes { get; set; }
    }
}