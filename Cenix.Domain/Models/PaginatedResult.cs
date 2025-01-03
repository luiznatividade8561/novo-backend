using System.Collections.Generic;

namespace Cenix.Domain.Models
{
    /// <summary>
    /// Represents a paginated result set
    /// </summary>
    /// <typeparam name="T">The type of items in the result set</typeparam>
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (TotalCount + PageSize - 1) / PageSize;
    }
}
