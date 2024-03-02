using Application.Abstracts.Repositories;
using Application.Features.Queries.GetNutritionById;
using AutoMapper;
using MediatR;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryModel>
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public GetCategoryByIdQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.mapper=mapper;
            this.categoryRepository=categoryRepository;
        }

        public async Task<GetCategoryByIdQueryModel> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await categoryRepository.GetByIdAsync(request.Id);
            if (data == null)
                throw new DatabaseValidationException("Besin bulunamadı!");

            var mappedData = mapper.Map<GetCategoryByIdQueryModel>(data);
            return mappedData;
        }
    }
}
