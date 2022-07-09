using Core.DataAcccess;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserDal: IEntityRepository<User>
{
    Task<List<OperationClaim>> GetClaimsAsync(User user);
}