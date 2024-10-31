using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public IQueryable<TEntity> GetQuery()
    {
        return _dbSet.Where(x => !x.IsDeleted);
    }

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
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task InsertAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await this.SaveChangesAsync();
    }

    public async Task BulkInsertAsync(List<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await this.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
        _dbSet.Update(entity);
        await this.SaveChangesAsync();
    }

    public async Task BulkUpdate(List<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
        await this.SaveChangesAsync();
    }

    public async Task Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        await this.SaveChangesAsync();
    }

    public async Task BulkDelete(List<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
        await this.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}