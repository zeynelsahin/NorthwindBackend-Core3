using Core.Utilities.Results;
using Entities;

namespace Business.Abstract;

public interface IProductService
{
    IDataResult<Product> GetById(int productId);
    IDataResult<List<Product>> GetList();
    IDataResult<List<Product>> GetListByCategory(int categoryId);
    IResult Add(Product product);
    IResult Delete(Product product);
    IResult Update(Product product);
    Task<IDataResult<Product>> GetByIdAsync(int productId);
    Task<IDataResult<List<Product>>> GetListAsync();
    Task<IDataResult<List<Product>>> GetListByCategoryAsync(int categoryId);
    Task<IResult> AddAsync(Product product);
    Task<IResult> DeleteAsync(Product product);
    Task<IResult> UpdateAsync(Product product);
}