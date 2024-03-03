using Application.Abstracts.Repositories;
using Application.Features.Queries.GetNutritions;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetCategoryNutritions
{
    public class GetCategoryNutritionsQueryHandler : IRequestHandler<GetCategoryNutritionsQueryRequest, GetCategoryNutritionsQueryModel>
    {
        private readonly INutritionRepository nutritionRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public GetCategoryNutritionsQueryHandler(INutritionRepository nutritionRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.nutritionRepository=nutritionRepository;
            this.mapper=mapper;
            this.categoryRepository=categoryRepository;
        }

        public async Task<GetCategoryNutritionsQueryModel> Handle(GetCategoryNutritionsQueryRequest request, CancellationToken cancellationToken)
        {
            var query = nutritionRepository.AsQueryable();
            var data = await categoryRepository.GetByIdAsync(request.CategoryId);
            if (data is null)
                throw new DatabaseValidationException("Kategori bulunamadı!");


            if (request?.CategoryId != null && request.CategoryId != Guid.Empty)
            {
                query = query.Where(nutrition => nutrition.CategoryId == request.CategoryId);
            }

            var result = await query.ToListAsync();



            return new GetCategoryNutritionsQueryModel
            {
                CategoryId = request.CategoryId,
                Picture = data.Picture,
                CategoryName = data.Name,
                Nutritions = mapper.Map<List<GetNutritionsQueryModel>>(result)
            };
        }
    }
}
