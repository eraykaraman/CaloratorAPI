using Application.Abstracts.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetNutritionsByMostSearch
{
    public class GetNutritionsByMostSearchQueryHandler : IRequestHandler<GetNutritionsByMostSearchQueryRequest, List<GetNutritionsByMostSearchQueryModel>>
    {
        private readonly INutritionRepository nutritionRepository;

        public GetNutritionsByMostSearchQueryHandler(INutritionRepository nutritionRepository)
        {
            this.nutritionRepository = nutritionRepository;
        }

        public async Task<List<GetNutritionsByMostSearchQueryModel>> Handle(GetNutritionsByMostSearchQueryRequest request, CancellationToken cancellationToken)
        {
            var allNutritions = nutritionRepository.Get(null);

            var randomNutritions = await allNutritions.OrderBy(x => Guid.NewGuid()).Take(5).ToListAsync();

            var result = randomNutritions.Select(i => new GetNutritionsByMostSearchQueryModel
            {
                Id = i.Id,
                NutritionName = i.Name,
                Amount = i.Amount,
                Picture = i.Picture,
            }).ToList();

            return result;
        }
    }
}
