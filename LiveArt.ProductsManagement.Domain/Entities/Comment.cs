namespace LiveArt.ProductsManagement.Domain.Entities
{
    public class Comment : EntityBase
    {
        public int ProductId { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
    }
}
