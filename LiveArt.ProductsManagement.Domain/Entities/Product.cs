namespace LiveArt.ProductsManagement.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbnailImage { get; set; }
    }
}
