using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.Create
{
    public class CreateCategoryCommandRequest : IRequest<Guid>
    {
        public CreateCategoryCommandRequest()
        {
            
        }
        public CreateCategoryCommandRequest(string name, string picture)
        {
            Name=name;
            Picture=picture;
        }

        public string Name { get; set; }
        public string Picture { get; set; }
    }
}
