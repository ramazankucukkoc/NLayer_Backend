using NLayer_Backend_Core.DataAccess;
using NLayer_Backend_Core.Entities.Concrete;

namespace NLayer_Backend_DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
