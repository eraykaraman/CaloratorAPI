using Application.Abstracts.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQueryRequest, GetUserDetailQueryModel>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetUserDetailQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task<GetUserDetailQueryModel> Handle(GetUserDetailQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Models.User dbUser = null;

            if (request.Id != Guid.Empty)
            {
                dbUser = await userRepository.GetByIdAsync(request.Id);
            }
            else if (!string.IsNullOrEmpty(request.UserName))
            {
                dbUser = await userRepository.SingleOrDefaultAsync(u => u.UserName == request.UserName);
            }
            else
                return null;

            return mapper.Map<GetUserDetailQueryModel>(dbUser);
        }
    }
}
