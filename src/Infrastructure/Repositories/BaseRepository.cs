using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace Infrastructure.Repositories;

public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>>? predicate = null)
    {
        var query = _dbSet.Where(x => !x.IsDeleted);
        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return query;
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id).ConfigureAwait(false);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync().ConfigureAwait(false);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        if (predicate != null)
        {
            return await _dbSet.CountAsync(predicate).ConfigureAwait(false);
        }

        return await _dbSet.CountAsync().ConfigureAwait(false);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate).ConfigureAwait(false);
    }

    public async Task InsertAsync(TEntity entity, Guid? createdBy = null)
    {
        if (entity == null) return;

        entity.CreatedBy = createdBy ?? Guid.Empty;
        await _dbSet.AddAsync(entity).ConfigureAwait(false);
        await this.SaveChangesAsync();
    }

    public async Task BulkInsertAsync(List<TEntity> entities, Guid? createdBy = null)
    {
        if (entities == null || entities.Count == 0) return;
        foreach (TEntity entity in entities)
        {
            entity.CreatedBy = createdBy ?? Guid.Empty;
        }
        await _dbSet.AddRangeAsync(entities).ConfigureAwait(false);
        await this.SaveChangesAsync();
    }

    public async Task Update(TEntity entity, Guid? modifiedBy = null)
    {
        if (entity == null) return;

        entity.ModifiedBy = modifiedBy;
        entity.ModifiedDate = DateTime.UtcNow;
        _dbSet.Update(entity);
        await this.SaveChangesAsync();
    }

    public async Task BulkUpdate(List<TEntity> entities, Guid? modifiedBy = null)
    {
        if (entities == null || entities.Count == 0) return;
        foreach (TEntity entity in entities)
        {
            entity.ModifiedBy = modifiedBy;
            entity.ModifiedDate = DateTime.UtcNow;
        }

        _dbSet.UpdateRange(entities);
        await this.SaveChangesAsync();
    }

    public async Task Delete(TEntity entity, Guid? deletedBy = null)
    {
        if (entity == null) return;

        entity.IsDeleted = true;
        entity.DeletedBy = deletedBy;
        entity.DeletedDate = DateTime.UtcNow;
        _dbSet.Update(entity);
        await this.SaveChangesAsync();
    }

    public async Task BulkDelete(List<TEntity> entities, Guid? deletedBy = null)
    {
        if (entities == null || entities.Count == 0) return;

        foreach (TEntity entity in entities)
        {
            _dbSet.Entry(entity).State = EntityState.Deleted;
            entity.IsDeleted = true;
            entity.DeletedBy = deletedBy;
            entity.DeletedDate = DateTime.UtcNow;
        }
        _dbSet.UpdateRange(entities);
        await this.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync().ConfigureAwait(false);
    }
}