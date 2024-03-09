namespace KolevDiamonds.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>();

        IQueryable<T> AllReadOnly<T>();
    }
}
