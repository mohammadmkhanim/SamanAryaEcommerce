using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using static Application.Products.Create;

namespace Application.Validators.Products
{
    public class CreateCommandValidator : AbstractValidator<Application.Products.Create.Command>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("نام نمی تواند خالی باشد.")
                                .MaximumLength(40).WithMessage("نام حداکثر می تواند 40 کاراکتر باشد.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("قیمت نمی تواند خالی باشد.")
                                .GreaterThan(0).WithMessage("قیمت باید بیشتر از صفر باشد.");
            RuleFor(x => x.ImageName).NotEmpty().WithMessage("نام نمی تواند خالی باشد.");
        }
    }
}