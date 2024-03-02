using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.ChangePassword
{
    public class ChangeUserPasswordCommandRequest: IRequest<bool>
    {
        public ChangeUserPasswordCommandRequest(Guid? userId, string oldPassword, string newPassword)
        {
            this.UserId=userId;
            this.OldPassword=oldPassword;
            this.NewPassword=newPassword;
        }

        public Guid? UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
