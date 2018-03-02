using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TheVault.Models
{
    public class TheVaultEntities : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get;  set;}
        public DbSet<Category> Producers { get; set; }
    }
}