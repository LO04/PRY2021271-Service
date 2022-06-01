using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Montrac.API.Domain.DataObjects.Authentication;
using Montrac.API.Domain.Models;
using Montrac.API.Domain.Repository;
using Montrac.API.Settings;

namespace Montrac.API.Authentication
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

        public async Task<AuthenticationResponse?> Authenticate(AuthenticationRequest request)
        {
            var isGuid = Guid.TryParse(request.Email, out _);
            User user = null;
            if (isGuid)
            {
                user = await UserRepository.FirstOrDefaultAsync(x => x.Identification == request.Email && x.Password == request.Password);
            }
            else
            {
                user = await UserRepository.FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password);
            }
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
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}