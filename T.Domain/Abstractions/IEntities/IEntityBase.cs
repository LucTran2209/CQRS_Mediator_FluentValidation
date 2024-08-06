namespace T.Domain.Abstractions.IEntities
{
    public interface IEntityBase<Tkey>
    {
        Tkey? Id { get; }
    }
}
