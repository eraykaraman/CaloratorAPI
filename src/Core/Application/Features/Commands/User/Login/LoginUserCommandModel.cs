using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.Login
{
    public class LoginUserCommandModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public float Age { get; set; }
        public string Token { get; set; }
    }
}
