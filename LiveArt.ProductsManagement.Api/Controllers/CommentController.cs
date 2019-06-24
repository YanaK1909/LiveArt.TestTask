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
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CommentModel>> Get()
        {
            var comments = commentRepository.GetAll();

            return comments.Select(x => CommentEntityToModel(x)).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<CommentModel>> Get(int id)
        {
            var comments = commentRepository.GetByProductId(id);

            return comments.Select(x => CommentEntityToModel(x)).OrderByDescending(x => x.Id).ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] CommentModel model)
        {
            var entity = CommentModelToEntity(model);
                        
            commentRepository.AddOrUpdate(entity);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            commentRepository.Delete(id);
        }
        
        private CommentModel CommentEntityToModel(Comment entity)
        {
            return new CommentModel
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                Author = entity.Author,
                Message = entity.Message
            };
        }

        private Comment CommentModelToEntity(CommentModel model)
        {
            return new Comment
            {
                Id = model.Id,
                ProductId = model.ProductId,
                Author = model.Author,
                Message = model.Message
            };
        }
    }
}
