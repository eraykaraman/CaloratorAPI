using Application.Abstracts.Repositories;
using MediatR;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, Guid>
    {
        private readonly ICategoryRepository categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository=categoryRepository;
        }

        public async Task<Guid> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var dbCategory = await categoryRepository.GetByIdAsync(request.Id);
            if (dbCategory is null)
                throw new DatabaseValidationException("Kategori bulunamadı!");

            await categoryRepository.DeleteAsync(dbCategory);
            return request.Id;
        }
    }
}
