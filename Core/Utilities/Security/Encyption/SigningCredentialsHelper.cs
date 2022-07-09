using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encyption;

public class SigningCredentialsHelper
{
    public static SigningCredentials CreateSingCredentials(SecurityKey securityKey)
    {
        return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        
    }
}