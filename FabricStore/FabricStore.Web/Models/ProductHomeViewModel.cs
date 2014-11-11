namespace FabricStore.Web.Models
{
    using FabricStore.Models;
    using FabricStore.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ProductHomeViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public virtual Category Category { get; set; }
    }
}