using System.Collections.Generic;
using LiveArt.ProductsManagement.Domain.Entities;

namespace LiveArt.ProductsManagement.Domain.Contracts.Repositories
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        IEnumerable<Comment> GetByProductId(int productId);
        void DeleteByProductId(int productId);
    }
}
