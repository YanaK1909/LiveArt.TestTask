using System;
using System.Collections.Generic;
using System.Text;

namespace LiveArt.ProductsManagement.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<T> where T : IEntityBase
    {
        void AddOrUpdate(T entity);
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
