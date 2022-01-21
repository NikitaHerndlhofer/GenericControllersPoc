using MinimalGenericApi.DataAccess.Abstractions;

namespace MinimalGenericApi.DataAccess;

public class InMemoryGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : IEntity
{
    private readonly IDictionary<Guid, TEntity> _inMemoryDatabase;

    public InMemoryGenericRepository()
    {
        _inMemoryDatabase = new Dictionary<Guid, TEntity>();
    }

    public Task<Guid> CreateAsync(TEntity item)
    {
        item.Id = Guid.NewGuid();
        _inMemoryDatabase.Add(item.Id, item);

        return Task.FromResult(item.Id);
    }

    public Task<TEntity?> FindByIdAsync(Guid id)
    {
        return Task.FromResult(_inMemoryDatabase.TryGetValue(id, out var entity) ? entity : default);
    }

    public Task<IEnumerable<TEntity>> GetAsync()
    {
        return Task.FromResult(_inMemoryDatabase.Values.ToList().AsEnumerable());
    }

    public Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate)
    {
        return Task.FromResult(_inMemoryDatabase.Values.Where(predicate).ToList().AsEnumerable());
    }

    public Task<bool> RemoveAsync(TEntity item)
    {
        return Task.FromResult(_inMemoryDatabase.Remove(item.Id));
    }

    public Task<bool> UpdateAsync(TEntity item)
    {
        if (!_inMemoryDatabase.ContainsKey(item.Id))
            return Task.FromResult(false);

        _inMemoryDatabase[item.Id] = item;
        return Task.FromResult(true);
    }
}