using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstracts.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
