using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Portfolio Name CANNOT be empty !");
            RuleFor(x => x.ImageURL).NotEmpty().WithMessage("ImageURL CANNOT be empty !");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Value CANNOT be empty !");
            RuleFor(x=>x.Price).NotEmpty().WithMessage($"{nameof(PortfolioValidator)}");

        }

    }
}
