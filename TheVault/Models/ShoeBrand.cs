using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    public class ShoeBrand
    {
        [Key]
        public int ShoeBrandID { get; set; }
        [Display(Name = "Shoe Brand")]
        public string Brands { get; set; }
    }
}