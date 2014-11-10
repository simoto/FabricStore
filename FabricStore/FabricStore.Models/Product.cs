namespace FabricStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        private ICollection<Comment> comments;
        private ICollection<Tag> tags;

        public Product()
        {
            this.comments = new HashSet<Comment>();
            this.tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }


        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        public int ManufactirerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public bool IsAvailable { get; set; }

        public decimal AvailableAmount { get; set; }

        public DataType DataAdded { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
