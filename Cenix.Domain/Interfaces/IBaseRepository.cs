using Cenix.Domain.Entities;

namespace Cenix.Domain.Interfaces
{
    /// <summary>
    /// Base repository interface providing common CRUD operations and query capabilities
    /// </summary>
    /// <typeparam name="TEntity">The type of entity this repository works with</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<(IEnumerable<TEntity> Items, int TotalCount)> GetPaginatedAsync(int page, int pageSize);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<bool> ExistsAsync(int id);
        /// <summary>
        /// Gets an IQueryable for complex queries. Can be used with PaginateAsync extension method
        /// for custom pagination without repeating Skip/Take logic.
        /// Example: await repository.Query().Where(x => x.IsActive).PaginateAsync(page, pageSize);
        /// </summary>
        /// <param name="enableTracking">If false, disables change tracking for better performance in read-only scenarios</param>
        /// <returns>An IQueryable for building complex queries</returns>
        IQueryable<TEntity> Query(bool enableTracking = true);
    }
}
