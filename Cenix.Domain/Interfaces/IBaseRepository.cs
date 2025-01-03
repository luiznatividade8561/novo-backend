using System.Collections.Generic;
using System.Threading.Tasks;
using Cenix.Domain.Entities;
using Cenix.Domain.Models;

namespace Cenix.Domain.Interfaces
{
    /// <summary>
    /// Base repository interface providing common CRUD operations
    /// </summary>
    /// <typeparam name="TEntity">The type of entity this repository works with</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<PaginatedResult<TEntity>> GetPaginatedAsync(int page, int pageSize);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<bool> ExistsAsync(int id);
        
        /// <summary>
        /// Gets a filtered and paginated result set based on the provided criteria
        /// </summary>
        /// <param name="page">The page number (1-based)</param>
        /// <param name="pageSize">The size of each page</param>
        /// <param name="enableTracking">If false, disables change tracking for better performance in read-only scenarios</param>
        /// <returns>A paginated result containing the filtered items</returns>
        Task<PaginatedResult<TEntity>> GetFilteredAsync(int page, int pageSize, bool enableTracking = false);
    }
}
