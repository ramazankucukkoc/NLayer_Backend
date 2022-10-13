using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NLayer_Backend_Business.Constants;
using NLayer_Backend_Core.Extensions;
using NLayer_Backend_Core.Utilities.Interceptors;
using NLayer_Backend_Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Backend_Business.BusinessAspects.Autofac
{
    public class SecuredOperation:MethodInterception
    {
        private string[] _roles;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        private IHttpContextAccessor _httpContextAccessor;
        
        protected override void OnBefore(IInvocation invocation)
        {
            var roleCliams = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleCliams.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);

        }

    }
}
