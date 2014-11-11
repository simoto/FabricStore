namespace FabricStore.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FabricStore.Models;

    public sealed class MigrationConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public MigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "FabricStore.Data.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }
     
            ICollection<Tag> tags = new List<Tag>()
            {
                new Tag() { Name = "Вълна" },
                new Tag() { Name = "Коприна" },
                new Tag() { Name = "Сатен" },
                new Tag() { Name = "Дантела" },
                new Tag() { Name = "Полиестер" },
                new Tag() { Name = "Памук" }
            };

            foreach (var tag in tags)
            {
                context.Tags.Add(tag);
            }

            IList<Category> categories = new List<Category>()
            {
                new Category() { Name = "Denim" },
                new Category() { Name = "Clouth" },
                new Category() { Name = "Camoflague" }
            };

            Manufacturer manufacturer = new Manufacturer() { Name = "US Fabric" };

            ApplicationUser user = new ApplicationUser() { UserName = "test", Email = "test@test.test" };

            List<Product> products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                products.Add(new Product()
                {
                    Name = "Black Denim" + i,
                    Price = 10.00m,
                    Category = categories[i % 3],
                    Image = "http://itschool.bg/application/uploads/tutorials/gallery/tutorials/100/8.jpg",
                    Description = "the best fabric description" + i,
                    Manufacturer = manufacturer,
                    IsAvailable = true,
                    AvailableAmount = 300 + i
                });
            }

            context.Products.AddOrUpdate(products.ToArray());
            context.SaveChanges();
        }
    }
}
