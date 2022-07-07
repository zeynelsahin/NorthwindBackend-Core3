using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAcccess;

public interface IEntityRepository<T> where T:class,IEntity,new()
{
    T Get(Expression<Func<T,bool>> filter);
    List<T> GetList(Expression<Func<T, bool>>? filter = null);
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    
    Task<T> GetAsync(Expression<Func<T,bool>> filter);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>>? filter = null);
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);


}