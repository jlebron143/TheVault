using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Date")]
        public DateTime? PostDate { get; set; }
        public string Title { get; set; }
        [MaxLength(509)]
        public string Message { get; set; }
        public string Image { get; set; } 
        public bool New { get; set; }
        public bool Used { get; set; } 

        public string UserID { get; set; }

        public int ShoeBrandID { get; set; }
        [ForeignKey("ShoeBrandID")]

        public virtual ShoeBrand ShoeBrand { get; set; }
        [ForeignKey("Size")]
        public int SizeId { get; set; }
        public Size Size { get; set; }


    }
}