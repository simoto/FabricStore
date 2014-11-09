namespace FabricStore.Data
{
    using FabricStore.Models;

    public interface IUowData
    {
        IRepository<Product> Products { get; }

        IRepository<Category> Categories { get; }

        IRepository<Manufacturer> Manufacturers { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Tag> Tags { get; }

        int SaveChanges();
    }
}
