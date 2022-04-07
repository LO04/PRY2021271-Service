using System.ComponentModel.DataAnnotations;

namespace Montrac.Api.DataObjects.Authentication
{
    public class AuthenticationRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}