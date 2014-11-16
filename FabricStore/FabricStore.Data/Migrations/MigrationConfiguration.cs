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
                new Category() { Name = "����" },
                new Category() { Name = "�������" },
                new Category() { Name = "�����" },
                new Category() { Name = "����" },
                new Category() { Name = "����" },
                new Category() { Name = "�����" },
                new Category() { Name = "���������" },
                new Category() { Name = "�����" },
                new Category() { Name = "�������" }
            };

            Manufacturer manufacturer = new Manufacturer() { Name = "US Fabric" };
            var image = new Bitmap(Image.FromFile("C:/Temps/vikoza.jpg"));

            List<Product> products = new List<Product>();
            products.Add(new Product()
            {
                Name = "���������� ����",
                Price = 11.00m,
                Category = categories[0],
                Image = this.ImageToByteArray(image),
                Description = "������ � ���� ����� �� �������� �������� �� ����������� �� ����� ������� �����.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 200,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "����" },
                    new Tag() { Name = "�����������" }
                }
            });
            products.Add(new Product()
            {
                Name = "���� ���������",
                Price = 8.00m,
                Category = categories[0],
                Image = this.ImageToByteArray(image),
                Description = "������ � ���� ����� �� �������� �������� �� ����������� �� ����� ������� �����.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 150,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "���������" },
                    new Tag() { Name = "����" }
                }
            });
            products.Add(new Product()
            {
                Name = "������� ����",
                Price = 10.00m,
                Category = categories[1],
                Image = this.ImageToByteArray(image),
                Description = "������� � � ��� ����� � ����� �� �������� �� ����������� �� �����, ������� �������, ������� � �.�.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 250,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "�������" },
                    new Tag() { Name = "����" }
                }
            });
            products.Add(new Product()
            {
                Name = "������� �����",
                Price = 12.00m,
                Category = categories[1],
                Image = this.ImageToByteArray(image),
                Description = "������� � � ��� ����� � ����� �� �������� �� ����������� �� �����, ������� �������, ������� � �.�.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 220,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "�������" },
                    new Tag() { Name = "�����" }
                }
            });
            products.Add(new Product()
            {
                Name = "�����",
                Price = 9.00m,
                Category = categories[2],
                Image = this.ImageToByteArray(image),
                Description = "������� �� �������� �� ��������� �� ����� ����� ��������� �� ������ �����.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 250,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "�����" }
                }
            });
            products.Add(new Product()
            {
                Name = "����",
                Price = 14.00m,
                Category = categories[3],
                Image = this.ImageToByteArray(image),
                Description = "���� ���� �� �������� �������� �� �����, ������, ������ � ����� ���������.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 100,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "����" },
                    new Tag() { Name = "����" }
                }
            });
            products.Add(new Product()
            {
                Name = "����",
                Price = 15.00m,
                Category = categories[4],
                Image = this.ImageToByteArray(image),
                Description = "������ � ����, ����� �� �������� �� ������� �������, ������, ����� ����� � �.�.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 130,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "����" },
                    new Tag() { Name = "�����" }
                }
            });
            products.Add(new Product()
            {
                Name = "����� �� ������",
                Price = 5.00m,
                Category = categories[5],
                Image = this.ImageToByteArray(image),
                Description = "100% ����� �� �������� �������� �� ����������� �� ������ �����, ������, ������� � �.�.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 140,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "�����" },
                    new Tag() { Name = "������" }
                }
            });
            products.Add(new Product()
            {
                Name = "��������� �����",
                Price = 7.00m,
                Category = categories[6],
                Image = this.ImageToByteArray(image),
                Description = "����������� � ���� ����� �� �������� �� ����������� �� �������, �����, ����� � �.�.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 150,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "���������" },
                    new Tag() { Name = "�����" }
                }
            });
            products.Add(new Product()
            {
                Name = "������ ���������",
                Price = 8.00m,
                Category = categories[7],
                Image = this.ImageToByteArray(image),
                Description = "���� ��������",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 150,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "������" },
                    new Tag() { Name = "��������" }
                }
            });
            products.Add(new Product()
            {
                Name = "�������� �������",
                Price = 8.00m,
                Category = categories[8],
                Image = this.ImageToByteArray(image),
                Description = "���� ��������",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 250,
                DataAdded = DateTime.Now,
                Tags = new[] 
                { 
                    new Tag() { Name = "��������" },
                    new Tag() { Name = "�������" }
                }
            });

            context.Products.AddOrUpdate(products.ToArray());
            context.SaveChanges();
        }

        private void SeedTags(ApplicationDbContext context)
        {
            ICollection<Tag> tags = new List<Tag>()
            {
                new Tag() { Name = "�����" },
                new Tag() { Name = "�������" },
                new Tag() { Name = "�����" },
                new Tag() { Name = "�������" },
                new Tag() { Name = "���������" },
                new Tag() { Name = "�����" }
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
