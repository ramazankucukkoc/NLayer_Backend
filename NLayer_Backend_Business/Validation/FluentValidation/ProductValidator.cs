using FluentValidation;
using NLayer_BackendEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Backend_Business.Validation.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(p=>p.Name).Length(2,30);
            RuleFor(p=>p.Price).NotEmpty();
            RuleFor(p=>p.Price).GreaterThanOrEqualTo(1);
            RuleFor(p => p.Price).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.Name).Must(StartWithWithA);

        }

        private bool StartWithWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
