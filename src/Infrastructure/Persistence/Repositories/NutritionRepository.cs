using Application.Abstracts.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class NutritionRepository : GenericRepository<Nutrition>, INutritionRepository
    {
        public NutritionRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

    }
}
