using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetNutritionById
{
    public class GetNutritionByIdQueryRequest : IRequest<GetNutritionByIdQueryModel>
    {
       
        public GetNutritionByIdQueryRequest()
        {
            
        }
        public GetNutritionByIdQueryRequest(Guid id)
        {
            Id=id;
        }

        public Guid Id { get; set; }
    }
}
