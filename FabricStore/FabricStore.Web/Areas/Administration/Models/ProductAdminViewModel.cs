namespace FabricStore.Web.Areas.Administration.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using FabricStore.Models;

    public class ProductAdminViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase Image { get; set; }

        [Required]
        public string Description { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public bool IsAvailable { get; set; }

        public decimal AvailableAmount { get; set; }

        public DateTime DataAdded { get; set; }
    }
}