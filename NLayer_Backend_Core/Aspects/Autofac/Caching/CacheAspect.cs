using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using NLayer_Backend_Core.CrossCuttingConcerns.Caching;
using NLayer_Backend_Core.Utilities.Interceptors;
using NLayer_Backend_Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Backend_Core.Aspects.Autofac.Caching
{
    public class CacheAspect:MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration=60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //PorductManager.GetByCategory(1,ssdaade); bunu yapıyor aşagıdaki kodlar birden fazla paremetre bil gelse.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments= invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {//cachede varsa burası çalışıyor.
                invocation.ReturnValue = _cacheManager.Get(key);
                return;//return; bitir demektir.
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);

        }
    }
}
