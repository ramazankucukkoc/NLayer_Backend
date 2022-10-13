
using Castle.DynamicProxy;
using FluentValidation;
using NLayer_Backend_Core.CrossCuttingConcerns.Validation;
using NLayer_Backend_Core.Utilities.Interceptors;
using NLayer_Backend_Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Backend_Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //yoldagın type IValidator tipindemi kontrol ediyoruz.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }
            _validatorType = validatorType;
        }
        //Biz burada öbür metodlarıda kullanabiliriz fakat validation
        //işlemi oldugu için sadece OnBefore metodunu kullandık çünkü 
        //metoda girmeden business katmanında dogrulama işlemi yapacagız.
        protected override void OnBefore(IInvocation invocation)
        {
            //Bu kodda ProductValidator new işlemi gerçekleştirdik.Zaten diyoruz tipi IValidator diye
            //(IValidator)
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //Burada ProductValidator derdeki base classın yani abstractclassı Product getirecek.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //Örnegin business daki ekleme işlemindeki Product sınıfı biribirine eşit mi bakıyor.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }

    }
}
