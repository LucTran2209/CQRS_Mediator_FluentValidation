using T.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace T.Persistence
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assemply);

        // Code template
        public DbSet<Product> Products { get; set; }
    }
}
