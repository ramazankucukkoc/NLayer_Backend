using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NLayer_Backend_Core.CrossCuttingConcerns.Caching;
using NLayer_Backend_Core.CrossCuttingConcerns.Caching.Microsoft;
using NLayer_Backend_Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Backend_Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            //redise gerçersek yarın öbürgün buraya yazmamız yeterli olacaktır.
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
