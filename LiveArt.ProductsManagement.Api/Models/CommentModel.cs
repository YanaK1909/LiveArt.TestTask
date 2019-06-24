namespace LiveArt.ProductsManagement.Api.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
    }
}
