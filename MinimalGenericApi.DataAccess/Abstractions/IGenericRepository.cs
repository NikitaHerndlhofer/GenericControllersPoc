namespace MinimalGenericApi.DataAccess.Abstractions;

public interface IGenericRepository<TEntity> where TEntity : IEntity
{
    Task<Guid> CreateAsync(TEntity item);
    Task<TEntity?> FindByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate);
    Task<bool> RemoveAsync(TEntity item);
    Task<bool> UpdateAsync(TEntity item);
}