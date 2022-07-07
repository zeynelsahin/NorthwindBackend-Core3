using Core.DataAcccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities;

namespace DataAccess.Concrete.EntityFramework;

public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
{
}