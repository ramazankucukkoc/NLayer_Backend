using NLayer_Backend_Business.Abstract;
using NLayer_Backend_Business.BusinessAspects.Autofac;
using NLayer_Backend_Business.Constants;
using NLayer_Backend_Business.Validation.FluentValidation;
using NLayer_Backend_Core.Aspects.Autofac.Caching;
using NLayer_Backend_Core.Aspects.Autofac.Logging;
using NLayer_Backend_Core.Aspects.Autofac.Perfomance;
using NLayer_Backend_Core.Aspects.Autofac.Transaction;
using NLayer_Backend_Core.Aspects.Autofac.Validation;
using NLayer_Backend_Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using NLayer_Backend_Core.Utilities.Results;
using NLayer_Backend_DataAccess.Abstract;
using NLayer_BackendEntities.Concrete;

namespace NLayer_Backend_Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator),Priority =1)]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            //Business codes örneğin eklenen bir ismin database olup olmadıgını burada kodlanacak.


            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAddded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        [PerformanceAspect(5)]
        public IDataResult<List<Product>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }
       // [SecuredOperation("Product.List,Admin")]
        [CacheAspect(10)]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());

        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            //_productDal.Add(product);
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
