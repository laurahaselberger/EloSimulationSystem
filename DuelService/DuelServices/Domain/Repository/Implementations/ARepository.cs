using System.Linq.Expressions;
using Domain.Repository.Interfaces;

namespace Domain.Repository.Implementations;

public abstract class ARepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> ReadAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<TEntity>> ReadAllAsync(int start, int count)
    {
        throw new NotImplementedException();
    }

    public Task<List<TEntity>> ReadAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> CreateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}