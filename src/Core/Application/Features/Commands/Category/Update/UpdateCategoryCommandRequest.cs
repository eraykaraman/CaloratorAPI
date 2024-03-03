using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.Update
{
    public class UpdateCategoryCommandRequest : IRequest<Guid>
    {
        public UpdateCategoryCommandRequest()
        {
            
        }
        public UpdateCategoryCommandRequest(Guid ıd, string name, string picture)
        {
            Id=ıd;
            Name=name;
            Picture=picture;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}
