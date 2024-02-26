using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetNutritionByName
{
    public class GetNutritionsByNameQueryRequest : IRequest<List<GetNutritionsByNameModel>>
    {
        public GetNutritionsByNameQueryRequest()
        {
            
        }

        public GetNutritionsByNameQueryRequest(string searchText)
        {
            SearchText=searchText;
        }

        public string SearchText { get; set; }
    }
}
