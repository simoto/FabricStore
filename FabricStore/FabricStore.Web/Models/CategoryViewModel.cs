namespace FabricStore.Web.Models
{
    using FabricStore.Models;
    using FabricStore.Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}