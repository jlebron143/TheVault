using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    public class Comment
    {
        [Key]

        public int CommentID { get; set; }

        public string Message { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CommentDate { get; set; }

        public string UserID { get; set; }

        [ForeignKey("Post")]
        public int PostID { get; set; }
        public Post Post { get; set; }

    }
}