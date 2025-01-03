using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cenix.Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for IQueryable to support common operations like pagination
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Applies pagination to an IQueryable, returning both the paginated items and total count
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query</typeparam>
        /// <param name="query">The IQueryable to paginate</param>
        /// <param name="page">The page number (1-based)</param>
        /// <param name="pageSize">The size of each page</param>
        /// <returns>A tuple containing the paginated items and total count</returns>
        public static async Task<(IEnumerable<T> Items, int TotalCount)> PaginateAsync<T>(
            this IQueryable<T> query,
            int page,
            int pageSize)
        {
            var totalCount = await query.CountAsync();
            
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
