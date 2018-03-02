using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    [Bind(Exclude="ItemId")]
    public class Item
    {
        
        [Key]
        [ScaffoldColumn(false)]
        public int ItemId { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Producer")]
        public int ProducerId { get; set; }

        [Required(ErrorMessage ="An item title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Range(0.1,50000,ErrorMessage ="Price must be between 0.1 and 50000")]
        public decimal Price { get; set; }

        [DisplayName("Item Art Url")]
        [StringLength(1024)]
        public string ItemArtUrl { get; set; }
        public virtual Category Category { get; set; }
        public virtual Producer Producer { get; set; }
    }
}