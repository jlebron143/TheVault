﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheVault.Models
{
    public class Cart
    {
        [Key] 
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public string UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual IEnumerable<Item> Items { get; set;  }
       
       

    }
}