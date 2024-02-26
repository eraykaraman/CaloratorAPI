using Application.Abstracts.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetNutritionByName
{
    public class GetNutritionsByNameQueryHandler : IRequestHandler<GetNutritionsByNameQueryRequest, List<GetNutritionsByNameModel>>
    {
        private readonly INutritionRepository nutritionRepository;

        public GetNutritionsByNameQueryHandler(INutritionRepository nutritionRepository)
        {
            this.nutritionRepository=nutritionRepository;
        }

        public async Task<List<GetNutritionsByNameModel>> Handle(GetNutritionsByNameQueryRequest request, CancellationToken cancellationToken)
        {
            var result = nutritionRepository
              .Get(i => EF.Functions.Like(i.Name, $"%{request.SearchText}%"))
              .Select(i => new GetNutritionsByNameModel
              {
                  Id = i.Id,
                  NutritionName = i.Name,
              });

            return await result.ToListAsync(cancellationToken);

        }
    }
}
