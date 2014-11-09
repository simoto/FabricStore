namespace FabricStore.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
