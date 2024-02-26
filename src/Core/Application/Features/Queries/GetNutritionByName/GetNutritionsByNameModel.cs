using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetNutritionByName
{
    public class GetNutritionsByNameModel
    {
        public Guid Id { get; set; }
        public string NutritionName { get; set; }
    }
}
