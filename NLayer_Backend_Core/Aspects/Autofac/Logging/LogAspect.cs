using Castle.DynamicProxy;
using NLayer_Backend_Core.CrossCuttingConcerns.Logging;
using NLayer_Backend_Core.CrossCuttingConcerns.Logging.Log4Net;
using NLayer_Backend_Core.Utilities.Interceptors;
using NLayer_Backend_Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Backend_Core.Aspects.Autofac.Logging
{
    public class LogAspect:MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType!=typeof(LoggerServiceBase))
            {
                throw new Exception(AspectMessages.WrongLoggerType);
            }
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));

        }
        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParemeters = new List<LogParemeter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParemeters.Add(new LogParemeter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }    
               
            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParemeters = logParemeters
            };
            return logDetail;

        }
    }
}
