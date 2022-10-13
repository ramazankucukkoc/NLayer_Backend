using NLayer_Backend_Core.Entities.Concrete;

namespace NLayer_Backend_Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);

        void Add(User user);

        User GetByMail(string email);


    }
}
