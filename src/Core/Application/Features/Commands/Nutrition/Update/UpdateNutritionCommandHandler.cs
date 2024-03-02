using Application.Abstracts.Repositories;
using AutoMapper;
using MediatR;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Nutrition.Update
{
    public class UpdateNutritionCommandHandler : IRequestHandler<UpdateNutritionCommandRequest, Guid>
    {
        private readonly INutritionRepository nutritionRepository;
        private readonly IMapper mapper;

        public UpdateNutritionCommandHandler(INutritionRepository nutritionRepository, IMapper mapper)
        {
            this.nutritionRepository=nutritionRepository;
            this.mapper=mapper;
        }

        public async Task<Guid> Handle(UpdateNutritionCommandRequest request, CancellationToken cancellationToken)
        {
            var dbNutrition = await nutritionRepository.GetByIdAsync(request.Id);
            if (dbNutrition is null)
                throw new DatabaseValidationException("Besin bulunamadı!");

            mapper.Map(request, dbNutrition);
            var rows = await nutritionRepository.UpdateAsync(dbNutrition);

            if(rows > 1)
            {
                //TODO
            }

            return dbNutrition.Id;

        }
    }
}
