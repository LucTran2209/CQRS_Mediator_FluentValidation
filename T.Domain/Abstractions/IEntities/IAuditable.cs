namespace T.Domain.Abstractions.IEntities
{
    public interface IAuditable : IDateTracking, IUserTracking, ISoftDelete
    {

    }
}
