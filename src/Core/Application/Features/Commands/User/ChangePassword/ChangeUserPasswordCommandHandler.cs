using Application.Abstracts.Repositories;
using Application.Extensions;
using MediatR;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.ChangePassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommandRequest, bool>
    {
        private readonly IUserRepository userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            this.userRepository=userRepository;
        }
        public async Task<bool> Handle(ChangeUserPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue)
                throw new ArgumentNullException(nameof(request.UserId));

            var dbUser = await userRepository.GetByIdAsync(request.UserId.Value);

            if (dbUser is null)
                throw new DatabaseValidationException("Kullanıcı bulunamadı!");

            var encPass = PasswordEncryptor.Encrpt(request.OldPassword);
            if (dbUser.Password != encPass)
                throw new DatabaseValidationException("Eski şifre yanlış!");

            dbUser.Password = PasswordEncryptor.Encrpt(request.NewPassword);

            await userRepository.UpdateAsync(dbUser);

            return true;
        }
    }
}
