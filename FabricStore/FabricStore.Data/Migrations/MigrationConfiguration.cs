namespace FabricStore.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FabricStore.Models;
    using System.IO;

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

            ApplicationUser user = new ApplicationUser() { UserName = "test", Email = "test@test.test" };

            var image = new Bitmap(Image.FromFile("C:/Temps/vikoza.jpg"));

            List<Product> products = new List<Product>();

            products.Add(new Product()
            {
                Name = "���������� ����",
                Price = 11.00m,
                Category = categories[0],
                Image = this.imageToByteArray(image),
                Description = "������ � ���� ����� �� �������� �������� �� ����������� �� ����� ������� �����.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 200
            });
            products.Add(new Product()
            {
                Name = "���� ���������",
                Price = 8.00m,
                Category = categories[0],
                Image = this.imageToByteArray(image),
                Description = "������ � ���� ����� �� �������� �������� �� ����������� �� ����� ������� �����.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 150
            });
            products.Add(new Product()
            {
                Name = "������� ����",
                Price = 10.00m,
                Category = categories[1],
                Image = this.imageToByteArray(image),
                Description = "������� � � ��� ����� � ����� �� �������� �� ����������� �� �����, ������� �������, ������� � �.�.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 250
            });
            products.Add(new Product()
            {
                Name = "������� �����",
                Price = 12.00m,
                Category = categories[1],
                Image = this.imageToByteArray(image),
                Description = "������� � � ��� ����� � ����� �� �������� �� ����������� �� �����, ������� �������, ������� � �.�.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 220
            });
            products.Add(new Product()
            {
                Name = "�����",
                Price = 9.00m,
                Category = categories[2],
                Image = this.imageToByteArray(image),
                Description = "������� �� �������� �� ��������� �� ����� ����� ��������� �� ������ �����.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 250
            });
            products.Add(new Product()
            {
                Name = "����",
                Price = 14.00m,
                Category = categories[3],
                Image = this.imageToByteArray(image),
                Description = "���� ���� �� �������� �������� �� �����, ������, ������ � ����� ���������.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 100
            });
            products.Add(new Product()
            {
                Name = "����",
                Price = 15.00m,
                Category = categories[4],
                Image = this.imageToByteArray(image),
                Description = "������ � ����, ����� �� �������� �� ������� �������, ������, ����� ����� � �.�.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 130
            });
            products.Add(new Product()
            {
                Name = "����� �� ������",
                Price = 5.00m,
                Category = categories[5],
                Image = this.imageToByteArray(image),
                Description = "100% ����� �� �������� �������� �� ����������� �� ������ �����, ������, ������� � �.�.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 140
            });
            products.Add(new Product()
            {
                Name = "��������� �����",
                Price = 7.00m,
                Category = categories[6],
                Image = this.imageToByteArray(image),
                Description = "����������� � ���� ����� �� �������� �� ����������� �� �������, �����, ����� � �.�.",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 150
            });
            products.Add(new Product()
            {
                Name = "������ ���������",
                Price = 8.00m,
                Category = categories[7],
                Image = this.imageToByteArray(image),
                Description = "���� ��������",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 150
            });
            products.Add(new Product()
            {
                Name = "�������� �������",
                Price = 8.00m,
                Category = categories[8],
                Image = this.imageToByteArray(image),
                Description = "���� ��������",
                Manufacturer = manufacturer,
                IsAvailable = true,
                AvailableAmount = 250
            });

            context.Products.AddOrUpdate(products.ToArray());
            context.SaveChanges();
        }

        private byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }        
    }
}
