using NLayer_Backend_Core.Utilities.Results;
using NLayer_BackendEntities.Concrete;

namespace NLayer_Backend_Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByCategory(int categoryId);
        IResult Add(Product product);
        IResult Update(Product product);

        IResult Delete(Product product);

        IResult TransactionalOperation(Product product);
    }
}
