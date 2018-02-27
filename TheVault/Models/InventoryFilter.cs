using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    public class InventoryFilter
    {
        [Key]
        public IEnumerable<string> Brands { get; set; }
        public int MinSize { get; set; }
        public int MaxSize { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }

        public bool IsEmpty
        {
            get
            {
                return Brands == null &&
                        MinPrice == 0 &&
                        MaxPrice == 0 &&
                        MinSize == 0 &&
                        MaxSize == 0;


            }
        }
        
    }
}