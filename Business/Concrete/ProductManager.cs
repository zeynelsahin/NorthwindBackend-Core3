using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;

namespace Business.Concrete;

public class ProductManager: IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
    }

    public IDataResult<List<Product>> GetList()
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
    }

    public IDataResult<List<Product>> GetListByCategory(int categoryId)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());
    }

    public IResult Add(Product product)
    {
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
    }

    public IResult Delete(Product product)
    {
        _productDal.Delete(product);
        return new SuccessResult(Messages.ProductDeleted);
    }

    public IResult Update(Product product)
    {
        _productDal.Update(product);
        return new SuccessResult(Messages.ProductUpdated);
    }

    public async Task<IDataResult<Product>> GetByIdAsync(int productId)
    {
        return new SuccessDataResult<Product>(await _productDal.GetAsync(p=>p.ProductId==productId));
    }

    public async Task<IDataResult<List<Product>>> GetListAsync()
    {
        return new SuccessDataResult<List<Product>>(await _productDal.GetListAsync());
    }
    [CacheAspect(duration:1)]
    public async Task<IDataResult<List<Product>>> GetListByCategoryAsync(int categoryId)
    {
        return new SuccessDataResult<List<Product>>(await _productDal.GetListAsync(p => p.CategoryId == categoryId));
    }

    [ValidationAspect(typeof(ProductValidator),Priority = 1)]
    [TransactionScopeAspect(Priority = 2)]
    [CacheRemoveAspect("IProductService.Get")]
    public async Task<IResult> AddAsync(Product product)
    {
        ValidationTool.Validate(new ProductValidator(),product);
        await _productDal.AddAsync(product);
        return new SuccessResult(Messages.ProductAdded);
    }

    public async Task<IResult> DeleteAsync(Product product)
    {
        await _productDal.DeleteAsync(product);
        return new SuccessResult(Messages.ProductDeleted);
    }

    public async Task<IResult> UpdateAsync(Product product)
    {
        await _productDal.UpdateAsync(product);
        return new SuccessResult(Messages.ProductAdded);
    }
    [TransactionScopeAspect]
    public async Task<IResult> TransactionOperationAsync(Product product)
    {
        await _productDal.UpdateAsync(product);
        await _productDal.AddAsync(product);
        return new SuccessResult(Messages.ProductUpdated);
    }
}