using NLayer_Backend_Core.Entities.Concrete;
using NLayer_Backend_Core.Utilities.Results;
using NLayer_Backend_Core.Utilities.Security.Jwt;
using NLayer_BackendEntities.Dtos;

namespace NLayer_Backend_Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);

        IDataResult<User> Login(UserForLoginDto userForLogin);

        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
