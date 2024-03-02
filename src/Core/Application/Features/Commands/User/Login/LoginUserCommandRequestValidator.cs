using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.Login
{
    public class LoginUserCommandRequestValidator : AbstractValidator<LoginUserCommandRequest>
    {
        public LoginUserCommandRequestValidator()
        {

            RuleFor(i => i.EmailAddress)
                .NotNull()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("İlgili adres geçerli bir mail adresi değil.");

            RuleFor(i => i.Password)
                .NotNull()
                .MinimumLength(6)
                .WithMessage("Şifre en az 6 karakterden oluşmalı.");
        }
    }
}
