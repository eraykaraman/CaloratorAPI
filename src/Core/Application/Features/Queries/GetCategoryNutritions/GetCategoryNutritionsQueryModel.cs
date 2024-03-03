using Application.Features.Queries.GetNutritions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetCategoryNutritions
{
    public class GetCategoryNutritionsQueryModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Picture { get; set; }
        public List<GetNutritionsQueryModel> Nutritions { get; set; }
    }
}
