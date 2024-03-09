
namespace KolevDiamonds.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        public IQueryable<T> All<T>()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> AllReadOnly<T>()
        {
            throw new NotImplementedException();
        }
    }
}
