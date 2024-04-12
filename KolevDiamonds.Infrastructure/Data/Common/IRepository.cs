namespace KolevDiamonds.Infrastructure.Data.Common
{
    /// <summary>
    /// All operations are asynchronous
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// All records in a table
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        IQueryable<T> All<T>() where T : class;


        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        IQueryable<T> AllReadOnly<T>() where T : class;

        /// <summary>
        /// Saves all made changes in trasaction
        /// </summary>
        /// <returns>Error code</returns>
        Task<int> SaveChangesAsync();


        /// <summary>
        /// Adds entity to the database
        /// </summary>
        /// <param>Entity to add</param>
        Task AddAsync<T>(T entity) where T : class;
    }
}
