using Microsoft.EntityFrameworkCore;
using T.Domain.Entities;
using T.Infastructure.Abstraction;
using T.Persistence;
using T.Persistence.RepositoryInterface;

namespace T.Infastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public bool Insert(Product entity)
        {
            try
            {
                _dbContext.Products.Add(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> FindByIdAsync(Guid id)
        {
            try
            {
                var product = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Product entity)
        {
            try
            {
                _dbContext.Products.Update(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
