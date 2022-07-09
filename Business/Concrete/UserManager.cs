using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class UserManager: IUserService
{
    private IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public Task<List<OperationClaim>> GetClaimsAsync(User user)
    {
        return _userDal.GetClaimsAsync(user);
    }

    public Task AddAsync(User user)
    {
         return _userDal.AddAsync(user);
    }

    public async Task<User> GetByMailAsync(string email)
    {
        return await _userDal.GetAsync(u => u.Email == email);
    }
}