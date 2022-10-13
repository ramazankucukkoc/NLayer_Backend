using NLayer_Backend_Core.Utilities.Results;
using NLayer_BackendEntities.Concrete;

namespace NLayer_Backend_Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
    }
}
