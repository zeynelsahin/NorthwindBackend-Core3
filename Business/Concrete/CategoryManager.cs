using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete;

public class CategoryManager: ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public IDataResult<Category> GetById(int categoryId)
    {
        return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
    }

    public IDataResult<List<Category>> GetList()
    {
        return new SuccessDataResult<List<Category>>(_categoryDal.GetList());
    }

    public IResult Add(Category category)
    {
        _categoryDal.Add(category);
        return new SuccessResult(Messages.CategoryAdded);
    }

    public IResult Delete(Category category)
    {
        _categoryDal.Delete(category);
        return new SuccessResult(Messages.CategoryDeleted);
    }

    public IResult Update(Category category)
    {
        _categoryDal.Update(category);
        return new SuccessResult(Messages.CategoryUpdated);
    }

    public async Task<IDataResult<Category>> GetByIdAsync(int categoryId)
    {
        return new SuccessDataResult<Category>(await _categoryDal.GetAsync(c => c.CategoryId == categoryId));
    }

    public async Task<IDataResult<List<Category>>> GetListAsync()
    {
        return new SuccessDataResult<List<Category>>(await _categoryDal.GetListAsync());
    }

    public async Task<IResult> AddAsync(Category category)
    {
         await _categoryDal.AddAsync(category);
        return new SuccessResult(Messages.ProductAdded);
    }

    public async Task<IResult> DeleteAsync(Category category)
    {
        await _categoryDal.DeleteAsync(category);
        return new SuccessResult(Messages.CategoryDeleted);
    }

    public async Task<IResult> UpdateAsync(Category category)
    {
        await _categoryDal.UpdateAsync(category);
        return new SuccessResult(Messages.CategoryUpdated);
    }
}