using Application.Abstracts.Repositories;
using AutoMapper;
using MediatR;
using Persistence.Exceptions;
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
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CreateNutritionCommandHandler(INutritionRepository nutritionRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.nutritionRepository=nutritionRepository;
            this.mapper=mapper;
            this.categoryRepository=categoryRepository;
        }

        public async Task<Guid> Handle(CreateNutritionCommandRequest request, CancellationToken cancellationToken)
        {
            var nutrition = mapper.Map<Domain.Models.Nutrition>(request);
            var category = await categoryRepository.GetByIdAsync(request.CategoryId);
            if(category == null)
                throw new DatabaseValidationException("Kategori bulunamadı! Var olmayan kategoriye besin eklemezsiniz.");
            await nutritionRepository.AddAsync(nutrition);
            return nutrition.Id;
        }
    }
}
