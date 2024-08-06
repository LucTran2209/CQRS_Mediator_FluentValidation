using T.Infastructure.Repositories;
using T.Persistence;
using T.Persistence.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace T.Infastructure.Common
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;    
        
        public EFUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbContext GetDbContext() => _context;

        public async Task SaveChangeAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync();

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

        public void RollBack()
        {
            var changedEntries = _context.ChangeTracker.Entries()
            .Where(e => e.State != EntityState.Unchanged)
            .ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        private IProductRepository productRepository;
        public IProductRepository ProductRepository =>  productRepository = new ProductRepository(_context);
          
    }
}
