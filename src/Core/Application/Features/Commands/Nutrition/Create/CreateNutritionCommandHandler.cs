using Application.Abstracts.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Nutrition.Create
{
    public class CreateNutritionCommandHandler : IRequestHandler<CreateNutritionCommandRequest, Guid>
    {
        private readonly INutritionRepository nutritionRepository;
        private readonly IMapper mapper;

        public CreateNutritionCommandHandler(INutritionRepository nutritionRepository, IMapper mapper)
        {
            this.nutritionRepository=nutritionRepository;
            this.mapper=mapper;
        }

        public async Task<Guid> Handle(CreateNutritionCommandRequest request, CancellationToken cancellationToken)
        {
            var nutrition = mapper.Map<Domain.Models.Nutrition>(request);
            await nutritionRepository.AddAsync(nutrition);
            return nutrition.Id;
        }
    }
}
