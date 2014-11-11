namespace FabricStore.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using FabricStore.Models;
    using FabricStore.Web.Infrastructure.Mapping;

    public class ProductHomeViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public virtual Category Category { get; set; }
    }
}