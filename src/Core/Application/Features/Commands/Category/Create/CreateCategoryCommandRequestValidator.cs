using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.Create
{
    public class CreateCategoryCommandRequestValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandRequestValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("Kategori adı gereklidir.");

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("Kategori resmi gereklidir.");
        }
    }
}
