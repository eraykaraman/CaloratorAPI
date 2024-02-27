using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetCategoryNutritions
{
    public class GetCategoryNutritionsQueryRequest : IRequest<GetCategoryNutritionsQueryModel>
    {
        public GetCategoryNutritionsQueryRequest(Guid categoryId)
        {
            CategoryId=categoryId;
        }

        public Guid CategoryId { get; set; }
    }
}
