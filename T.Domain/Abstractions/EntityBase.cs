using T.Domain.Abstractions.IEntities;

namespace T.Domain.Abstractions
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey? Id { get; set; }
    }
}
