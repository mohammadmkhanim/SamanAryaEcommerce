using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using static Application.Products.Create;

namespace Application.Validators.Roles
{
    public class CreateCommandValidator : AbstractValidator<Application.Roles.SeedRoles.Command>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Names).NotEmpty().WithMessage("نام ها نمی تواند خالی باشد.");
        }
    }
}