using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetNutritions
{
    public class GetNutritionsQueryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Picture { get; set; }
        public float Calorie { get; set; }
        public float Carbohydrate { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Fiber { get; set; }
        public float Cholesterol { get; set; }
        public float Sodium { get; set; }
        public float Potassium { get; set; }
        public float Calcium { get; set; }
        public float VitaminA { get; set; }
        public float VitaminC { get; set; }
        public float Iron { get; set; }
    }
}
