using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.Update
{
    public class UpdateUserCommandRequestValidator : AbstractValidator<UpdateUserCommandRequest>
    {
        public UpdateUserCommandRequestValidator()
        {
            RuleFor(i => i.EmailAddress)
                .Cascade(CascadeMode.Stop)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("İlgili adres geçerli bir mail adresi değil.");

            RuleFor(x => x.UserName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Kullanıcı adı boş olamaz.");

            RuleFor(x => x.Height)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .When(x => x.Height.HasValue)
                .WithMessage("Boy pozitif bir değer olmalıdır.");

            RuleFor(x => x.Weight)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .When(x => x.Weight.HasValue)
                .WithMessage("Kilo pozitif bir değer olmalıdır.");

            RuleFor(x => x.Age)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .When(x => x.Age.HasValue)
                .WithMessage("Yaş pozitif bir değer olmalıdır.");
        }
    }
}
