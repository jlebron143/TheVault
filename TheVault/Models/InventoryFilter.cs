using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    public class InventoryFilter
    {
        [Key]
        public IEnumerable<string> Brands { get; set; }

       
        public int MinSize { get; set; }
        [ForeignKey("Min Size")]

        public int MaxSize { get; set; }
        [ForeignKey("Max Size")]

        public decimal MinPrice { get; set; }
        [ForeignKey("Min Price")]

        public decimal MaxPrice { get; set; }
        [ForeignKey("Max Price")]

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