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

        public string Note  { get; set; }

        public string UserID { get; set; }

        [ForeignKey("Message")]
        public int MessageID{ get; set; }
        public Message Message { get; set; }
    }
}