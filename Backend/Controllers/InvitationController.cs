using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrac.API.Domain.Models;
using Montrac.API.Domain.Services;

namespace Montrac.API.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/invitation")]
    public class InvitationController : ControllerBase
    {
        private readonly IInvitationService _invitationService;

        public InvitationController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }

        [HttpPut("{invitationId}/{userId}/{accept}")]
        public async Task<IActionResult> AcceptInvitation(int invitationId, int userId, bool accept)
        {
            var result = await _invitationService.AcceptInvitation(invitationId, userId, accept);

            if (result != true)
                return BadRequest("Invitation couldnt be accepted");

            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Invitation request)
        {
            var result = await _invitationService.CreateInvitation(request);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpDelete("invitationId")]
        public async Task<IActionResult> DeleteAsync(int invitationId)
        {
            var result = await _invitationService.DeleteInvitation(invitationId);

            if (result != true)
                return BadRequest("Invitation couldnt be deleted");

            return Ok(true);
        }

        [HttpGet]
        public async Task<IEnumerable<Invitation>> Search([FromQuery] int? managerId, [FromQuery] int? guestId, [FromQuery] string? guestEmail)
        {
            return await _invitationService.Search(managerId, guestId, guestEmail);
        }
    }
}
