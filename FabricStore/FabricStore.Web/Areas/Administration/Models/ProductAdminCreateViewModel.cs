using FabricStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FabricStore.Web.Areas.Administration.Models
{
    public class ProductAdminCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase Image { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public decimal AvailableAmount { get; set; }

        [Required]
        public DateTime DataAdded { get; set; }
    }
}