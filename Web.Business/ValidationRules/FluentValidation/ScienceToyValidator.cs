using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities.Concrete;

namespace Web.Business.ValidationRules.FluentValidation
{
    public class ScienceToyValidator : AbstractValidator<PlushToy>
    {
        public ScienceToyValidator()
        {
            RuleFor(s => s.Name).MinimumLength(4);
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.UnitPrice).GreaterThanOrEqualTo(100);
            RuleFor(s => s.Name).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
