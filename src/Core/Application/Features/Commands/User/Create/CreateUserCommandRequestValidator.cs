using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.Create
{
    public class CreateUserCommandRequestValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Ad boş olamaz.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Soyad boş olamaz.");

            RuleFor(i => i.EmailAddress)
                .NotNull()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("İlgili adres geçerli bir mail adresi değil.");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Kullanıcı adı boş olamaz.");

            RuleFor(i => i.Password)
                .NotNull()
                .MinimumLength(6)
                .WithMessage("Şifre en az 6 karakterden oluşmalı.");

            RuleFor(x => x.Height)
                .GreaterThan(0)
                .WithMessage("Boy pozitif bir değer olmalıdır.");

            RuleFor(x => x.Weight)
                .GreaterThan(0)
                .WithMessage("Kilo pozitif bir değer olmalıdır.");

            RuleFor(x => x.Age)
                .GreaterThan(0)
                .WithMessage("Yaş pozitif bir değer olmalıdır.");
        }

    }
}
