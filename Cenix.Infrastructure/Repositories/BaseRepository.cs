using Cenix.Domain.Entities;
using Cenix.Domain.Extensions;
using Cenix.Domain.Interfaces;
using Cenix.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Cenix.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await Query(enableTracking: false)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Query(enableTracking: false).ToListAsync();
        }

        public virtual async Task<(IEnumerable<TEntity> Items, int TotalCount)> GetPaginatedAsync(int page, int pageSize)
        {
            return await Query(enableTracking: false).PaginateAsync(page, pageSize);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            
            var entry = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return entry.Entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(x => x.CreatedAt).IsModified = false;
            
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            entity.DeletedAt = AppUtilities.GetDateTimeBrasilia();
            await UpdateAsync(entity);
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }

        public virtual IQueryable<TEntity> Query(bool enableTracking = true)
        {
            return enableTracking ? _dbSet : _dbSet.AsNoTracking();
        }
    }
}
