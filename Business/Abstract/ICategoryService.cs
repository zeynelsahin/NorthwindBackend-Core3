using Core.Utilities.Results;
using Entities;

namespace Business.Abstract;

public interface ICategoryService
{
    IDataResult<Category> GetById(int categoryId);
    IDataResult<List<Category>> GetList();
    IResult Add(Category category);
    IResult Delete(Category category);
    IResult Update(Category category);
    Task<IDataResult<Category>> GetByIdAsync(int categoryId);
    Task<IDataResult<List<Category>>> GetListAsync();
    Task<IResult> AddAsync(Category category);
    Task<IResult> DeleteAsync(Category category);
    Task<IResult> UpdateAsync(Category category);
}