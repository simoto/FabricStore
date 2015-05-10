namespace FabricStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
