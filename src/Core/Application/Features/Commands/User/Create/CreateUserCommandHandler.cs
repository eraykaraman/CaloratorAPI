using Application.Abstracts.Repositories;
using Application.Extensions;
using AutoMapper;
using MediatR;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper=mapper;
            this.userRepository=userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var existUser = await userRepository.SingleOrDefaultAsync(x => x.EmailAddress == request.EmailAddress);
            if (existUser is not null)
                throw new DatabaseValidationException("Bu mail adresi başka bir kullanıcı tarafından zaten kullanılıyor!");

            var dbUser = mapper.Map<Domain.Models.User>(request);
            dbUser.Password = PasswordEncryptor.Encrpt(dbUser.Password);

            var rows = await userRepository.AddAsync(dbUser);
            return dbUser.Id;
        }
    }
}
