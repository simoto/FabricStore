namespace FabricStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Required]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
