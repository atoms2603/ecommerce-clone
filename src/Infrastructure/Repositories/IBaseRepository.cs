using Entities;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> GetQuery();
    IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task InsertAsync(TEntity entity);
    Task BulkInsertAsync(List<TEntity> entities);
    Task Update(TEntity entity);
    Task BulkUpdate(List<TEntity> entities);
    Task Delete(TEntity entity);
    Task BulkDelete(List<TEntity> entities);
    Task<int> SaveChangesAsync();
}