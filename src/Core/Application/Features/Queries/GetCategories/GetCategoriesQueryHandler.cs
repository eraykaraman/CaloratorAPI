using Application.Abstracts.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<GetCategoriesQueryModel>>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository=categoryRepository;
            this.mapper=mapper;
        }

        public async Task<List<GetCategoriesQueryModel>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
           var data = await categoryRepository.GetAll();
           var mappedData = mapper.Map<List<GetCategoriesQueryModel>>(data);
           return mappedData.OrderBy(n => n.Name).ToList();
        }
    }
}
