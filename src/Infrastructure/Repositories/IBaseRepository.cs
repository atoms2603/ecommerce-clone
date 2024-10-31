using Entities;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task InsertAsync(TEntity entity, Guid? createdBy = null);
    Task BulkInsertAsync(List<TEntity> entities, Guid? createdBy = null);
    Task Update(TEntity entity, Guid? updateddBy = null);
    Task BulkUpdate(List<TEntity> entities, Guid? updateddBy = null);
    Task Delete(TEntity entity, Guid? deletedBy = null);
    Task BulkDelete(List<TEntity> entities, Guid? deletedBy = null);
    Task<int> SaveChangesAsync();
}