using NLayer_Backend_Core.DataAccess;
using NLayer_BackendEntities.Concrete;

namespace NLayer_Backend_DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
