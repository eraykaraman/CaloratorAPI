using Application.Abstracts.Repositories;
using Application.Extensions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandModel>
    {

        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private IConfiguration configuration;

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        public async Task<LoginUserCommandModel> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var dbUser = await userRepository.SingleOrDefaultAsync(u => u.EmailAddress == request.EmailAddress);

            if (dbUser == null)
                throw new DatabaseValidationException("Kullanıcı bulunamadı!");

            var pass = PasswordEncryptor.Encrpt(request.Password);
            if (dbUser.Password != pass)
                throw new DatabaseValidationException("Şifre yanlış!");


            var result = mapper.Map<LoginUserCommandModel>(dbUser);

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, dbUser.EmailAddress),
                new Claim(ClaimTypes.NameIdentifier, dbUser.UserName),
                new Claim(ClaimTypes.NameIdentifier, dbUser.FirstName),
                new Claim(ClaimTypes.NameIdentifier, dbUser.LastName),
            };

            result.Token = GenerateToken(claims);

            return result;
        }

        private string GenerateToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthConfig:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(10);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiry,
                signingCredentials: creds,
                notBefore: DateTime.Now
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
