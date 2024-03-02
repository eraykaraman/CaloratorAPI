using Application.Abstracts.Repositories;
using Application.Features.Queries.GetNutritions;
using AutoMapper;
using MediatR;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetNutritionById
{
    public class GetNutritionByIdQueryHandler : IRequestHandler<GetNutritionByIdQueryRequest, GetNutritionByIdQueryModel>
    {
        private readonly INutritionRepository nutritionRepository;
        private readonly IMapper mapper;

        public GetNutritionByIdQueryHandler(INutritionRepository nutritionRepository, IMapper mapper)
        {
            this.nutritionRepository=nutritionRepository;
            this.mapper=mapper;
        }

        public async Task<GetNutritionByIdQueryModel> Handle(GetNutritionByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await nutritionRepository.GetByIdAsync(request.Id);
            if (data == null)
                throw new DatabaseValidationException("Besin bulunamadı!");

            var mappedData = mapper.Map<GetNutritionByIdQueryModel>(data);
            return mappedData;
            
        }
    }
}
