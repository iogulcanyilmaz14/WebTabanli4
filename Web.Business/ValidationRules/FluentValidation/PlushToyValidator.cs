using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities.Concrete;

namespace Web.Business.ValidationRules.FluentValidation
{
   public class PlushToyValidator: AbstractValidator<PlushToy>
    {
        public PlushToyValidator()
        {
            RuleFor(p => p.Name).MinimumLength(4);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(100);
            RuleFor(p => p.Name).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
