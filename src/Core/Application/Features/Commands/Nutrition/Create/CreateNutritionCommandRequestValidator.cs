using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Nutrition.Create
{
    public class CreateNutritionCommandRequestValidator : AbstractValidator<CreateNutritionCommandRequest>
    {
        public CreateNutritionCommandRequestValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Besin adı gereklidir.");

            RuleFor(x => x.Calorie)
                .GreaterThan(0)
                .WithMessage("Kalori 0'dan büyük olmalıdır.");

            RuleFor(x => x.Carbohydrate)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Karbonhidrat negatif olmamalıdır.");

            RuleFor(x => x.Protein)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Protein negatif olmamalıdır.");

            RuleFor(x => x.Fat)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Yağ negatif olmamalıdır.");

            RuleFor(x => x.Fiber)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Lif negatif olmamalıdır.");

            RuleFor(x => x.Cholesterol)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Kolesterol negatif olmamalıdır.");

            RuleFor(x => x.Sodium)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Sodyum negatif olmamalıdır.");

            RuleFor(x => x.Potassium)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Potasyum negatif olmamalıdır.");

            RuleFor(x => x.Calcium)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Kalsiyum negatif olmamalıdır.");

            RuleFor(x => x.VitaminA)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Vitamin A negatif olmamalıdır.");

            RuleFor(x => x.VitaminC)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Vitamin C negatif olmamalıdır.");

            RuleFor(x => x.Iron)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Demir negatif olmamalıdır.");

            RuleFor(x => x.CategoryId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Kategori boş olamaz.");
        }
    }
}
