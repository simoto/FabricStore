namespace FabricStore.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;

    using FabricStore.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class MigrationConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private UserManager<ApplicationUser> userManager;

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

            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            this.SeedRoles(context);
            this.SeedUsers(context);
            this.SeedCategoriesWithProducts(context);
            this.SeedTags(context);          
        }

        private void SeedCategoriesWithProducts(ApplicationDbContext context)
        {
            IList<Category> categories = new List<Category>()
            {
                new Category() { Name = "Вата" },
                new Category() { Name = "Вискоза" },
                new Category() { Name = "Вълна" },
                new Category() { Name = "Кожа" },
                new Category() { Name = "Плюш" },
                new Category() { Name = "Памук" },
                new Category() { Name = "Полиестер" },
                new Category() { Name = "Ликра" },
                new Category() { Name = "Текстил" }
            };

            Manufacturer manufacturer = new Manufacturer() { Name = "US Fabric" };
            var image = new Bitmap(Image.FromFile("C:/Temps/vikoza.jpg"));

            List<Product> products = new List<Product>();
            products.Add(new Product()
            {
                Name = "Двуконечна вата",
                Price = 11.00m,
                Category = categories[0],
                Image = this.ImageToByteArray(image),
                Description = "Ватата е плат който се използва предимно за изработката на някои спортни дрехи.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 200,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "Вата" },
                    new Tag() { Name = "Двуконечнка" }
                }
            });
            products.Add(new Product()
            {
                Name = "Вата полиестер",
                Price = 8.00m,
                Category = categories[0],
                Image = this.ImageToByteArray(image),
                Description = "Ватата е плат който се използва предимно за изработката на някои спортни дрехи.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 150,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "Полиестер" },
                    new Tag() { Name = "Вата" }
                }
            });
            products.Add(new Product()
            {
                Name = "Вискоза синя",
                Price = 10.00m,
                Category = categories[1],
                Image = this.ImageToByteArray(image),
                Description = "Вискоза с и без ликра – често се използва за изработката на рокли, вечерно облекло, тениски и т.н.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 250,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "Вискоза" },
                    new Tag() { Name = "Синя" }
                }
            });
            products.Add(new Product()
            {
                Name = "Вискоза ликра",
                Price = 12.00m,
                Category = categories[1],
                Image = this.ImageToByteArray(image),
                Description = "Вискоза с и без ликра – често се използва за изработката на рокли, вечерно облекло, тениски и т.н.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 220,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "Вискоза" },
                    new Tag() { Name = "Ликра" }
                }
            });
            products.Add(new Product()
            {
                Name = "Вълна",
                Price = 9.00m,
                Category = categories[2],
                Image = this.ImageToByteArray(image),
                Description = "Вълната се използва за направата на топли дрехи подходящи за зимния сезон.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 250,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "Вълна" }
                }
            });
            products.Add(new Product()
            {
                Name = "Кожа",
                Price = 14.00m,
                Category = categories[3],
                Image = this.ImageToByteArray(image),
                Description = "Този плат се използва предимно за чанти, обувки, колани и други аксесоари.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 100,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "Кожа" },
                    new Tag() { Name = "Плат" }
                }
            });
            products.Add(new Product()
            {
                Name = "Плюш",
                Price = 15.00m,
                Category = categories[4],
                Image = this.ImageToByteArray(image),
                Description = "Плюшът е плат, който се използва за спортно облекло, пижами, зимни дрехи и т.н.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 130,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "Плюш" },
                    new Tag() { Name = "Спорт" }
                }
            });
            products.Add(new Product()
            {
                Name = "Памук на райета",
                Price = 5.00m,
                Category = categories[5],
                Image = this.ImageToByteArray(image),
                Description = "100% ПАМУК се използва предимно за изработката на детски дрехи, пижами, тениски и т.н.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 140,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "Памук" },
                    new Tag() { Name = "Райета" }
                }
            });
            products.Add(new Product()
            {
                Name = "Полиестер щампа",
                Price = 7.00m,
                Category = categories[6],
                Image = this.ImageToByteArray(image),
                Description = "Полиестерът е плат който се използва за изработката на тениски, рокли, бельо и т.н.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 150,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "Полиестер" },
                    new Tag() { Name = "Щампа" }
                }
            });
            products.Add(new Product()
            {
                Name = "Цветни полиамиди",
                Price = 8.00m,
                Category = categories[7],
                Image = this.ImageToByteArray(image),
                Description = "Няма описание",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 150,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "Цветни" },
                    new Tag() { Name = "Полиамид" }
                }
            });
            products.Add(new Product()
            {
                Name = "Бродиран текстил",
                Price = 8.00m,
                Category = categories[8],
                Image = this.ImageToByteArray(image),
                Description = "Няма описание",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 250,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "Бродиран" },
                    new Tag() { Name = "Текстил" }
                }
            });

            context.Products.AddOrUpdate(products.ToArray());
            context.SaveChanges();
        }

        private void SeedTags(ApplicationDbContext context)
        {
            ICollection<Tag> tags = new List<Tag>()
            {
                new Tag() { Name = "вълна" },
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

            context.SaveChanges();
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("Admin"));
            context.SaveChanges();
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var adminUser = new ApplicationUser
            {
                Email = "admin@example.com",
                UserName = "admin@example.com"
            };

            this.userManager.Create(adminUser, "admin123456");

            this.userManager.AddToRole(adminUser.Id, "Admin");
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }        
    }
}
