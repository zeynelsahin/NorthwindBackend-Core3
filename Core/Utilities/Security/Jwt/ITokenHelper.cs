using Core.Entities.Concrete;

namespace Core.Utilities.Security.Jwt;

public interface ITokenHelper
{
    Task<AccessToken> CreateToken(User user, List<OperationClaim> operationClaims);
}