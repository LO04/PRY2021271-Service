using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrac.Api.Extensions;
using Montrac.Domain.DataObjects.Invitation;
using Montrac.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Montrac.api.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/invitation")]
    public class InvitationController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly IMapper Mapper;
        private readonly IInvitationService InvitationService;

        public InvitationController(IUserService userService, IMapper mapper, IInvitationService invitationService)
        {
            UserService = userService;
            Mapper = mapper;
            InvitationService = invitationService;
        }

        [HttpPut("{invitationId:int}/{userId:int}/{accept:bool}")]
        public async Task<IActionResult> AcceptInvitation(int invitationId, int userId, bool accept)
        {
            var result = await InvitationService.AcceptInvitation(invitationId, userId, accept);

            if (result != true)
                return BadRequest("Invitation couldnt be deleted");

            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewInvitation resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await InvitationService.CreateInvitation(Mapper.Map<NewInvitation, InvitationRequest>(resource));

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpDelete("programId")]
        public async Task<IActionResult> DeleteAsync(int invitationId)
        {
            var result = await InvitationService.DeleteInvitations(invitationId);

            if (result != true)
                return BadRequest("Invitation couldnt be deleted");

            return Ok(true);
        }

        [HttpGet]
        public async Task<IEnumerable<NewInvitation>> Search([FromQuery] int? managerId, [FromQuery] int? guestId)
        {
            var invitations = await InvitationService.Search(managerId, guestId);
            return Mapper.Map<IEnumerable<InvitationRequest>, IEnumerable<NewInvitation>>(invitations);
        }
    }
}
