using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using static Application.Products.Create;

namespace Application.Validators.Users
{
    public class GetQueryValidator : AbstractValidator<Application.Users.Get.Query>
    {
        public GetQueryValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("نام نمی تواند خالی باشد.")
                                .MaximumLength(40).WithMessage("نام حداکثر می تواند 40 کاراکتر باشد.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("رمز عبور نمی تواند خالی باشد.")
                                .MaximumLength(40).WithMessage("رمز عبور حداکثر می تواند 40 کاراکتر باشد.");
        }
    }
}