using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TheVault.Models;

namespace TheVault.ViewModels
{
    public class ShoppingCartViewModel
    {
        [Key]
        public Cart Cart { get; set; }
        public Decimal CartTotal { get; set; }
    }
}