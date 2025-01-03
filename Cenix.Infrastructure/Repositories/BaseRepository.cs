using Cenix.Domain.Entities;
using Cenix.Domain.Interfaces;
using Cenix.Domain.Models;
using Cenix.Domain.Utils;
using Cenix.Infrastructure.Context;
using Cenix.Infrastructure.Extensions;
using Cenix.Application.DTOs;
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

        public virtual async Task<PaginatedResult<TEntity>> GetPaginatedAsync(int page, int pageSize)
        {
            var result = await Query(enableTracking: false).PaginateAsync(page, pageSize);
            return new PaginatedResult<TEntity>
            {
                Items = result.Items,
                TotalCount = result.TotalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        protected virtual IQueryable<TEntity> ApplyFilters(IQueryable<TEntity> query, FilterParams filter)
        {
            // Filtra DeletedAt == null
            query = query.Where(x => x.DeletedAt == null);

            // Filtrar por ID se fornecido
            if (filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == filter.Id.Value);
            }

            // Filtrar coluna string com ILIKE se fornecido
            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                // Note: This is a placeholder. The actual string column should be specified
                // when implementing in derived repositories for specific entities
                // Example: query = query.Where(x => EF.Functions.ILike(x.Name, $"%{filter.SearchTerm}%"));
                throw new NotImplementedException(
                    "O método ApplyFilters deve ser sobrescrito na classe derivada para especificar " +
                    "qual coluna string deve ser usada com ILIKE.");
            }

            // Ordenação padrão por Id desc
            if (string.IsNullOrWhiteSpace(filter.OrderBy))
            {
                query = query.OrderByDescending(x => x.Id);
            }
            else
            {
                query = ApplyOrdering(query, filter.OrderBy, filter.OrderDirection);
            }

            return query;
        }

        public virtual async Task<PaginatedResult<TEntity>> GetFilteredAsync(FilterParams filter, bool enableTracking = false)
        {
            var query = Query(enableTracking);
            query = ApplyFilters(query, filter);
            
            var result = await query.PaginateAsync(filter.Page + 1, filter.PageSize); // Convert 0-based to 1-based
            return new PaginatedResult<TEntity>
            {
                Items = result.Items,
                TotalCount = result.TotalCount,
                Page = filter.Page,
                PageSize = filter.PageSize
            };
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

        protected virtual IQueryable<TEntity> ApplyOrdering(IQueryable<TEntity> query, string column, string? direction)
        {
            // Ordenação padrão por Id desc se a coluna não for reconhecida
            if (column.ToLower() != "id")
            {
                throw new NotImplementedException(
                    "O método ApplyOrdering deve ser sobrescrito na classe derivada para especificar " +
                    "as colunas disponíveis para ordenação.");
            }

            return direction?.ToLower() == "asc" 
                ? query.OrderBy(x => x.Id)
                : query.OrderByDescending(x => x.Id);
        }
    }
}
