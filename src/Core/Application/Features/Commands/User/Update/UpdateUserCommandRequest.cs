using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.Update
{
    public class UpdateUserCommandRequest : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? EmailAddress { get; set; }
        public string? UserName { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public float? Age { get; set; }
    }
}
