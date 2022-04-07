using Montrac.Domain.DataObjects.Invitation;
using Montrac.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.Services
{
    public interface IInvitationService
    {
        Task<IEnumerable<InvitationRequest>> Search(int? managerId = null, int? guestId = null);
        Task<Response<InvitationRequest>> CreateInvitation(InvitationRequest request);
        Task<bool> AcceptInvitation(int invitationId, int userId, bool accept);
        Task<bool> DeleteInvitations(int invitationId);
    }
}
