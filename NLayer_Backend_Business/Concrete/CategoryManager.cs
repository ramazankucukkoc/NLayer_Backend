using NLayer_Backend_Business.Abstract;
using NLayer_Backend_Core.Utilities.Results;
using NLayer_Backend_DataAccess.Abstract;
using NLayer_BackendEntities.Concrete;

namespace NLayer_Backend_Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }
    }
}
