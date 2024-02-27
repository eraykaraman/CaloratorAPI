using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.Login
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandModel>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public LoginUserCommandRequest()
        {

        }

        public LoginUserCommandRequest(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }
    }
}
