using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using static Application.Products.Create;

namespace Application.Validators.Orders
{
    public class CreateCommandValidator : AbstractValidator<Application.Orders.Create.Command>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("کاربر نمی تواند خالی باشد.");
            RuleFor(x => x.ProductIds).NotEmpty().WithMessage("محصولات نمی تواند خالی باشد.");
        }
    }
}