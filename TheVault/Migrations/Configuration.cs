namespace TheVault.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TheVault.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TheVault.Models.ApplicationDbContext context)
        {
            context.ShoeBrands.AddOrUpdate(x => x.ShoeBrandID,
    new ShoeBrand() { ShoeBrandID = 1, Brands = "- Please Select a Shoe Brand-" },
        new ShoeBrand() { ShoeBrandID = 2, Brands = "Adidas" },
        new ShoeBrand() { ShoeBrandID = 3, Brands = "Air Jordan" },
        new ShoeBrand() { ShoeBrandID = 4, Brands = "Nike" },
        new ShoeBrand() { ShoeBrandID = 5, Brands = "Reebok" },
        new ShoeBrand() { ShoeBrandID = 6, Brands = "Under Armour" }

    );

            context.Sizes.AddOrUpdate(x => x.SizeID,
                new Size() { SizeID = 1, Sizes = "- Please Select a Size-" },
                    new Size() { SizeID = 2, Sizes = "7.5" },
                    new Size() { SizeID = 3, Sizes = "8" },
                    new Size() { SizeID = 4, Sizes = "8.5" },
                    new Size() { SizeID = 5, Sizes = "9" },
                    new Size() { SizeID = 6, Sizes = "9.5" },
                    new Size() { SizeID = 7, Sizes = "10" },
                    new Size() { SizeID = 8, Sizes = "10.5" },
                    new Size() { SizeID = 9, Sizes = "11" },
                    new Size() { SizeID = 10, Sizes = "11.5" },
                    new Size() { SizeID = 11, Sizes = "12" },
                    new Size() { SizeID = 12, Sizes = "12.5" },
                    new Size() { SizeID = 13, Sizes = "13" },
                    new Size() { SizeID = 14, Sizes = "13.5" },
                    new Size() { SizeID = 15, Sizes = "14" },
                    new Size() { SizeID = 16, Sizes = "15" },
                    new Size() { SizeID = 17, Sizes = "16" },
                    new Size() { SizeID = 18, Sizes = "17" }
            
                );


        }
    }
}
