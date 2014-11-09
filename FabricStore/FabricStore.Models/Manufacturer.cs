namespace FabricStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        private ICollection<Product> laptops;

        public Manufacturer()
        {
            this.laptops = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.laptops; }
            set { this.laptops = value; }
        }
    }
}
