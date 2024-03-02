using Application.Abstracts.Repositories;
using AutoMapper;
using MediatR;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper=mapper;
            this.userRepository=userRepository;
        }

        public async Task<Guid> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var dbUser = await userRepository.GetByIdAsync(request.Id);
            if (dbUser is null)
                throw new DatabaseValidationException("Kullanıcı bulunamadı!");

            var dbEmailAddress = dbUser.EmailAddress;
            var dbUserName = dbUser.UserName;
            var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EmailAddress) != 0;
            var userNameChanged = string.CompareOrdinal(dbUserName, request.UserName) != 0;

            if (userNameChanged)
            {
                var existUserName = await userRepository.SingleOrDefaultAsync(x => x.UserName == request.UserName);


                if (existUserName is not null)
                    throw new DatabaseValidationException("Bu kullanıcı adı adresi başka bir kullanıcı tarafından zaten kullanılıyor!");
            }

            mapper.Map(request, dbUser);
            var rows = await userRepository.UpdateAsync(dbUser);

            //check if email changed
            if (emailChanged && rows > 0)
            {
                //TODO
            }
            return dbUser.Id;
        }
    }
}

