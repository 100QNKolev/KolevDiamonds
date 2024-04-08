using KolevDiamonds.Data;
using Microsoft.EntityFrameworkCore;

namespace KolevDiamonds.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext _context;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
        }

        private DbSet<T> DbSet<T> () where T : class
        {
            return this._context.Set<T>();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this._context.SaveChangesAsync();
        }
    }
}
