using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PlayerStatisticsService.Repositories.Interfaces;

namespace MatchmakingService.Repositories.Implementations;

public class ARepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly MatchmakingDbContext Context;
    protected readonly DbSet<TEntity> Table;

    public ARepository(MatchmakingDbContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        Table = context.Set<TEntity>();
    }

    public async Task<TEntity?> ReadAsync(int id) => await Table.FindAsync(id);

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter)
        => await Table.Where(filter).ToListAsync();

    public async Task<List<TEntity>> ReadAllAsync() => await Table.ToListAsync();

    public async Task<List<TEntity>> ReadAllAsync(int start, int count)
        => await Table.Skip(start).Take(count).ToListAsync();

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        Table.Add(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        Context.ChangeTracker.Clear();

        Table.Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Table.Remove(entity);
        await Context.SaveChangesAsync();
    }
}


