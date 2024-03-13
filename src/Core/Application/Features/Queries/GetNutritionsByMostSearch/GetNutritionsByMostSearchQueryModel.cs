using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetNutritionsByMostSearch
{
    public class GetNutritionsByMostSearchQueryModel
    {
        public Guid Id { get; set; }
        public string NutritionName { get; set; }
        public string Amount { get; set; }
        public string Picture { get; set; }
    }
}
