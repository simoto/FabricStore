namespace FabricStore.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using FabricStore.Models;
    
    public class FabricStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public FabricStoreDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public static FabricStoreDbContext Create()
        {
            return new FabricStoreDbContext();
        }
    }
}
