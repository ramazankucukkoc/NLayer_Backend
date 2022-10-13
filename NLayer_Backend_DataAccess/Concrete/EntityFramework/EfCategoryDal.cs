using NLayer_Backend_Core.DataAccess.EntityFramework;
using NLayer_Backend_DataAccess.Abstract;
using NLayer_Backend_DataAccess.Concrete.EntityFramework.Context;
using NLayer_BackendEntities.Concrete;

namespace NLayer_Backend_DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, AppDbContext>, ICategoryDal
    {
    }
}
