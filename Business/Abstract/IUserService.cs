using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Abstract;

public interface IUserService
{
    Task<List<OperationClaim>> GetClaimsAsync(User user);
    Task AddAsync(User user);
    Task<User> GetByMailAsync(string email);
}