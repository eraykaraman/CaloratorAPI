using Application.Features.Commands.User.Login;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.ChangePassword
{
    public class ChangeUserCommandRequestValidator : AbstractValidator<ChangeUserPasswordCommandRequest>
    {
        public ChangeUserCommandRequestValidator()
        {
            RuleFor(i => i.OldPassword)
                .NotNull()
                .MinimumLength(6)
                .WithMessage("Eski şifre en az 6 karakterden oluşmalı.");
            RuleFor(i => i.NewPassword)
                .NotNull()
                .MinimumLength(6)
                .WithMessage("Yeni şifre en az 6 karakterden oluşmalı.");
        }
    }
}
