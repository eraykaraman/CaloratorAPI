using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CategoryNutrition
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid NutritionId { get; set; }
        public Nutrition Nutrition { get; set; }
    }
}
