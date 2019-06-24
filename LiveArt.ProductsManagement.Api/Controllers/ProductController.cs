using System.Collections.Generic;
using System.Linq;
using LiveArt.ProductsManagement.Api.Models;
using LiveArt.ProductsManagement.Domain.Contracts.Repositories;
using LiveArt.ProductsManagement.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LiveArt.ProductsManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryBase<Product> productRepository;
        private readonly ICommentRepository commentRepository;

        public ProductController(IRepositoryBase<Product> productRepository, ICommentRepository commentRepository)
        {
            this.productRepository = productRepository;
            this.commentRepository = commentRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Get()
        {
            var products = productRepository.GetAll();

            return products.Select(x => ProductEntityToModel(x)).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ProductModel> Get(int id)
        {
            var product = productRepository.Get(id);
            var comments = commentRepository.GetByProductId(id);

            return ProductEntityToModel(product, comments);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ProductModel model)
        {
            var entity = ProductModelToEntity(model);
                        
            productRepository.AddOrUpdate(entity);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

        private ProductModel ProductEntityToModel(Product entity, IEnumerable<Comment> comments = null)
        {
            return new ProductModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ThumbnailImage = entity.ThumbnailImage,
                Comments = comments != null ? comments.Select(CommentEntityToModel).OrderByDescending(x => x.Id).ToList() : null
            };
        }

        private CommentModel CommentEntityToModel(Comment entity)
        {
            return new CommentModel
            {
                Id = entity.Id,
                Author = entity.Author,
                Message = entity.Message
            };
        }

        private Product ProductModelToEntity(ProductModel model)
        {
            return new Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ThumbnailImage = model.ThumbnailImage
            };
        }
    }
}
