using Montrac.API.Domain.Models;
using Montrac.API.Domain.Response;

namespace Montrac.API.Domain.Services
{
    public interface IInvitationService
    {
        Task<IEnumerable<Invitation>> Search(int? managerId = null, int? guestId = null, string? guestEmail = null);
        Task<Response<Invitation>> CreateInvitation(Invitation request);
        Task<bool> ConfirmPayment(string name, string email, string suscription);
        Task<bool> AcceptInvitation(int invitationId, int userId, bool accept);
        Task<bool> DeleteInvitation(int invitationId);
    }
}
