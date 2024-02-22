using Application.Abstracts.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetNutritions
{
    public class GetNutritionsQueryHandler : IRequestHandler<GetNutritionsQueryRequest, List<GetNutritionsQueryModel>>
    {
        private readonly INutritionRepository nutritionRepository;
        private readonly IMapper mapper;

        public GetNutritionsQueryHandler(INutritionRepository nutritionRepository, IMapper mapper)
        {
            this.nutritionRepository=nutritionRepository;
            this.mapper=mapper;
        }

        public async Task<List<GetNutritionsQueryModel>> Handle(GetNutritionsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await nutritionRepository.GetAll();
            var mappedData = mapper.Map<List<GetNutritionsQueryModel>>(data);
            return mappedData.OrderBy(n => n.Name).ToList();
        }
    }
}
