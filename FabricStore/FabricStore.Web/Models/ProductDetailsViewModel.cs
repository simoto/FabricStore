﻿namespace FabricStore.Web.Models
{
    using System.Collections.Generic;
    using FabricStore.Models;
    using FabricStore.Web.Infrastructure.Mapping;

    public class ProductDetailsViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<CommentViewModel> Comments { get; set; }
    }
}