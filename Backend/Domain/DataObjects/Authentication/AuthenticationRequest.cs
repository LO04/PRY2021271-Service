using System.ComponentModel.DataAnnotations;

namespace Montrac.API.Domain.DataObjects.Authentication
{
    public class AuthenticationRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}