using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Backend_Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        //object entity yazmamızın sebebi IDto ve IEntity referanslarının da yer alması içindir.
        public static void Validate(IValidator validator,object entity)
        {
            var context =new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
