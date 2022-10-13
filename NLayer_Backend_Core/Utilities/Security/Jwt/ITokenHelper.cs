using NLayer_Backend_Core.Entities.Concrete;

namespace NLayer_Backend_Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        //Tokene user vwrdik ve rollerini verdik..
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
