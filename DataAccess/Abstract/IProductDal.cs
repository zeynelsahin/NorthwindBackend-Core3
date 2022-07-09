using Core.DataAcccess;
using Entities;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IProductDal: IEntityRepository<Product>
{
    
}