using LiveArt.ProductsManagement.Domain.Contracts;

namespace LiveArt.ProductsManagement.Domain.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public int Id { get; set; }
    }
}
