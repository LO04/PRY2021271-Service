using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Montrac.Api.DataObjects.Authentication;
using Montrac.Api.Settings;
using Montrac.Domain.Models;
using Montrac.Domain.Repository;

namespace Montrac.Api.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> UserRepository;
        private readonly AppSettings AppSettings;

        public AuthenticationService(IRepository<User> userRepository, IOptions<AppSettings> appSettings)
        {
            UserRepository = userRepository;
            AppSettings = appSettings.Value;
        }

        public async Task<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            var user = await UserRepository.FirstOrDefaultAsync(x =>
                           x.Email == request.Email &&
                       x.Password == request.Password);

            if (user == null) return null;

            var token = GenerateJwtToken(user);
            return new AuthenticationResponse(user, token);
        }
        
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new (ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}