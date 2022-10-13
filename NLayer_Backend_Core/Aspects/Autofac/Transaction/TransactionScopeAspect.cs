using Castle.DynamicProxy;
using NLayer_Backend_Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NLayer_Backend_Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        
        //intercept ezmemiz sebebi tüm işlemleri transaction takip edilip program olumlu sonuçlanan kadar tüm işlemlere bakacak
        //eğer bir yerde hata varsa işlemleri geri döndürecektir.
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope trasnsactionScope=new TransactionScope())
            {
                try
                {
                    //Proceed() metodu işlemi başlatacak
                    //Complete() metodu işlemi bitirecektir.
                    invocation.Proceed();
                    trasnsactionScope.Complete();
                }
                catch (Exception)
                {
                    //Dispose() metodu işlemler başarısız olursa geri alacak.
                    trasnsactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
