using T.Domain.Abstractions.IRepositories;
using T.Domain.Entities;

namespace T.Persistence.RepositoryInterface
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {

    }
}
