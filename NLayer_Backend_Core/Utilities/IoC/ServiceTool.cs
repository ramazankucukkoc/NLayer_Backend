using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Backend_Core.Utilities.IoC
{
    public static class ServiceTool
    {
        //Service Tool sayesinde artık ben dotnettin kendi servislerine erişebiliyorum demektir.
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider=services.BuildServiceProvider();
            return services;
        }
    }
}
