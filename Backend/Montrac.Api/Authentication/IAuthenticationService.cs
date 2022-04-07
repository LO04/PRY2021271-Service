using System.Threading.Tasks;
using Montrac.Api.DataObjects.Authentication;
using Montrac.Domain.Models;

namespace Montrac.Api.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
        string GenerateJwtToken(User user);
    }
}