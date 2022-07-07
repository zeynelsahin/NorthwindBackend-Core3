using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAcccess.EntityFramework;

public class EfEntityRepositoryBase<TEntity,TContext>: IEntityRepository<TEntity> where TEntity : class,IEntity,new() where TContext: DbContext,new()
{
    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using var context = new TContext();
        return context.Set<TEntity>().SingleOrDefault(filter)!;
    }

    public List<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null)
    {
        using var context = new TContext();
        return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
    }

    public void Add(TEntity entity)
    {
        using var context= new TContext();
        var addedEntity = context.Entry(entity);
        addedEntity.State = EntityState.Added;
        context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        using var context= new TContext();
        var deletedEntity = context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
        context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        using var context= new TContext();
        var updatedEntity = context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        context.SaveChanges();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        await using var context = new TContext();
        return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
    }
    

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        await using var context = new TContext();
        return filter == null ? await context.Set<TEntity>().ToListAsync() : await context.Set<TEntity>().Where(filter).ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await using var context= new TContext();
        var addedEntity = context.Entry(entity);
        addedEntity.State = EntityState.Added;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        await using var context= new TContext();
        var deletedEntity = context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await using var context= new TContext();
        var updatedEntity = context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
}