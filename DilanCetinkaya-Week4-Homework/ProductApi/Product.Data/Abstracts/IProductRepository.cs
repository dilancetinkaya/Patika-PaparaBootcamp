using Product.Domain.Entities;

namespace Product.Data.Abstracts
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
    }
}
