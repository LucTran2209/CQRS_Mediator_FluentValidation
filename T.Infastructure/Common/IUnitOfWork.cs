using T.Persistence.RepositoryInterface;

namespace T.Infastructure.Common
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IProductRepository ProductRepository { get; }

        /// <summary>
        /// Call Save change from db context
        /// </summary>
        /// <returns></returns>
        Task SaveChangeAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Roll back data insert/update before save change
        /// </summary>
        /// <returns></returns>
        void RollBack();
    }
}
