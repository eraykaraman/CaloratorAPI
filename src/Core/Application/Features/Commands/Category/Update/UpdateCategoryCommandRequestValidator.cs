using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.Update
{
    public class UpdateCategoryCommandRequestValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandRequestValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Kategori id'si gereklidir.");

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("Kategori adı gereklidir.");

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("Kategori resmi gereklidir.");
        }
    }
}
