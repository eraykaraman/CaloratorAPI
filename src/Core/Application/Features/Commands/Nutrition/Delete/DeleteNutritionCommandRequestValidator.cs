using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Nutrition.Delete
{
    public class DeleteNutritionCommandRequestValidator : AbstractValidator<DeleteNutritionCommandRequest>
    {
        public DeleteNutritionCommandRequestValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Besin id'si gereklidir.");
        }
    }
}
