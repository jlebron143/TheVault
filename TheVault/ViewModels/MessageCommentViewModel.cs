using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheVault.Models;

namespace TheVault.ViewModels
{
    public class MessageCommentViewModel
    {
        public Message Message { get; set; }
        public List<Comment> Comments { get; set; }
    }
}