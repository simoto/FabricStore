namespace FabricStore.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using FabricStore.Models;
    using FabricStore.Web.Infrastructure.Mapping;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public PostCommentViewModel()
        {
        }

        public PostCommentViewModel(int productId)
        {
            this.ProductId = productId;
        }

        public int ProductId { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        [UIHint("MultiLineText")]
        [Display(Name = "Comment")]
        public string Content { get; set; }
    }
}