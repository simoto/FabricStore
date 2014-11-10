namespace FabricStore.Data.Migrations
{
    using FabricStore.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class MigrationConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "FabricStore.Data.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if(context.Products.Any())
            {
                return;
            }
     
            ICollection<Tag> tags = new List<Tag>()
            {
                new Tag(){ Name = "Вълна" },
                new Tag(){ Name = "Коприна" },
                new Tag(){ Name = "Сатен" },
                new Tag(){ Name = "Дантела" },
                new Tag(){ Name = "Полиестер" },
                new Tag(){ Name = "Памук" }
            };

            foreach (var tag in tags)
            {
                context.Tags.Add(tag);
            }

            IList<Category> categories = new List<Category>()
            {
                new Category(){ Name = "Denim" },
                new Category() { Name = "Clouth" },
                new Category() { Name = "Camoflague" }
            };

            Manufacturer manufacturer = new Manufacturer() { Name = "US Fabric" };

            ApplicationUser user = new ApplicationUser() { UserName = "test", Email = "test@test.test" };

            Product product = new Product()
            {
                Name = "Black Denim",
                Price = 10.00m,
                Category = categories[0],
                Image = "url",
                Description = "the best fabric description",
                Manufacturer = manufacturer,
                Tags = tags,
                IsAvailable = true,
                AvailableAmount = 300
            };

            context.Products.Add(product);
            context.SaveChanges();
            //this.Seed(context);
        }
    }
}
