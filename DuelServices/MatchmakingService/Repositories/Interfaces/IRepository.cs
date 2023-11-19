using System.Linq.Expressions;

namespace MatchmakingService.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter);
    Task<TEntity?> ReadAsync(int id);

    Task<List<TEntity>> ReadAllAsync(int start, int count);
    
    Task<List<TEntity>> ReadAllAsync();

    Task<TEntity> CreateAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
}