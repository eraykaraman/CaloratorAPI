using Application.Abstracts.Repositories;
using AutoMapper;
using MediatR;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, Guid>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository=categoryRepository;
            this.mapper=mapper;
        }

        public async Task<Guid> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Domain.Models.Category>(request);
            await categoryRepository.AddAsync(category);
            return category.Id;
        }
    }
}
