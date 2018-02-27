using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    public class PostCommentViewModel
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }
    }
}