using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        public string Subject { get; set; }
        [MaxLength(509)]
        public string Comment { get; set; }
        public string YourName { get; set; }
        public string EmailAddress { get; set; }


    }
}