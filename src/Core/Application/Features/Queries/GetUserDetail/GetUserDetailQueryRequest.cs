using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetUserDetail
{
    public class GetUserDetailQueryRequest : IRequest<GetUserDetailQueryModel>
    {
        public GetUserDetailQueryRequest(Guid id, string userName = null)
        {
            Id = id;
            UserName = userName;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}
