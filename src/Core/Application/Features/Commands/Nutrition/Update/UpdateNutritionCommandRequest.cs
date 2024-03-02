using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Nutrition.Update
{
    public class UpdateNutritionCommandRequest : IRequest<Guid>
    {
        public UpdateNutritionCommandRequest()
        {
            
        }
        public UpdateNutritionCommandRequest(Guid ıd, string name, string amount, string picture, float calorie, float carbohydrate, float protein, float fat, float fiber, float cholesterol, float sodium, float potassium, float calcium, float vitaminA, float vitaminC, float ıron)
        {
            Id=ıd;
            Name=name;
            Amount=amount;
            Picture=picture;
            Calorie=calorie;
            Carbohydrate=carbohydrate;
            Protein=protein;
            Fat=fat;
            Fiber=fiber;
            Cholesterol=cholesterol;
            Sodium=sodium;
            Potassium=potassium;
            Calcium=calcium;
            VitaminA=vitaminA;
            VitaminC=vitaminC;
            Iron=ıron;
        }

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
