using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryRequest : IRequest<GetCategoryByIdQueryModel>
    {
        public GetCategoryByIdQueryRequest(Guid ıd)
        {
            Id=ıd;
        }

        public GetCategoryByIdQueryRequest()
        {

        }
        public Guid Id { get; set; }
    }
}
