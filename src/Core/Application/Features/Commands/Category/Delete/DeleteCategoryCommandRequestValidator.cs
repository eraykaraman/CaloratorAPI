using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.Delete
{
    public class DeleteCategoryCommandRequestValidator : AbstractValidator<DeleteCategoryCommandRequest>
    {
        public DeleteCategoryCommandRequestValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Besin id'si gereklidir.");
        }
    }
}
