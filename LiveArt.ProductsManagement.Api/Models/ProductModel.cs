using System.Collections.Generic;

namespace LiveArt.ProductsManagement.Api.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbnailImage { get; set; }

        public List<CommentModel> Comments { get; set;}
    }
}
