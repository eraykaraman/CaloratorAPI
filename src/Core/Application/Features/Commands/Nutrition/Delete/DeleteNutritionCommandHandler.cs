using Application.Abstracts.Repositories;
using MediatR;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Nutrition.Delete
{
    public class DeleteNutritionCommandHandler : IRequestHandler<DeleteNutritionCommandRequest, Guid>
    {
        private readonly INutritionRepository nutritionRepository;

        public DeleteNutritionCommandHandler(INutritionRepository nutritionRepository)
        {
            this.nutritionRepository=nutritionRepository;
        }

        public async Task<Guid> Handle(DeleteNutritionCommandRequest request, CancellationToken cancellationToken)
        {
            var dbNutrition = await nutritionRepository.GetByIdAsync(request.Id);
            if (dbNutrition is null)
                throw new DatabaseValidationException("Besin bulunamadı!");

            await nutritionRepository.DeleteAsync(dbNutrition);
            return request.Id;
        }
    }
}
