using Cenix.Domain.Utils;

namespace Cenix.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public BaseEntity()
        {
            CreatedAt = AppUtilities.GetDateTimeBrasilia();
            UpdatedAt = AppUtilities.GetDateTimeBrasilia();
        }
    }
}
