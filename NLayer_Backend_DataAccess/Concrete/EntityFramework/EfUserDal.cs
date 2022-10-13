using NLayer_Backend_Core.DataAccess.EntityFramework;
using NLayer_Backend_Core.Entities.Concrete;
using NLayer_Backend_DataAccess.Abstract;
using NLayer_Backend_DataAccess.Concrete.EntityFramework.Context;

namespace NLayer_Backend_DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, AppDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new AppDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
