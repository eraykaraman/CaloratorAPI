using Application.Abstracts.Repositories;
using AutoMapper;
using Domain.Models;
using MediatR;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, Guid>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository=categoryRepository;
            this.mapper=mapper;
        }

        public async Task<Guid> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var dbCategory = await categoryRepository.GetByIdAsync(request.Id);
            if (dbCategory is null)
                throw new DatabaseValidationException("Kategori bulunamadı!");

            mapper.Map(request, dbCategory);
            var rows = await categoryRepository.UpdateAsync(dbCategory);

            if (rows > 1)
            {
                //TODO
            }
            return dbCategory.Id;

        }
    }
}
