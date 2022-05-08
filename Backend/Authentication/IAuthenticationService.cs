using Montrac.API.Domain.DataObjects.Authentication;
using Montrac.API.Domain.Models;

namespace Montrac.API.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
        string GenerateJwtToken(User user);
    }
}