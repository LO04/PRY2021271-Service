using Microsoft.EntityFrameworkCore;
using Montrac.API.Domain.Services;
using Montrac.API.Domain.Repository;
using Montrac.API.Domain.Models;
using Montrac.API.Domain.Response;

namespace Montrac.API.Services
{
    public class InvitationService : IInvitationService
    {
        private readonly IRepository<Invitation> _invitationRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InvitationService(IRepository<Invitation> invitationRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _invitationRepository = invitationRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AcceptInvitation(int invitationId, int userId, bool accept)
        {
            try
            {
                var invitation = await _invitationRepository.GetAsync(invitationId);
                if (invitation == null || invitation.IsDeleted || invitation.Status)
                    return false;

                var user = await _userRepository.GetAsync(userId);
                //if the invited user isnt the actual user
                if (user == null || user.IsDeleted || invitation.GuestId != user.Id)
                    return false;

                if (accept && !invitation.Status)
                {
                    //if the guest accept the invitation, its updated, otherwise its deleted.
                    //and to keep history of invitations only change status to accepted instead of delete the invitation
                    invitation.Status = true;
                    await _invitationRepository.UpdateAsync(invitation);
                }
                else
                {
                    invitation.IsDeleted = true;
                    await _invitationRepository.UpdateAsync(invitation);
                }

                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Response<Invitation>> CreateInvitation(Invitation request)
        {
            var guest = _userRepository.GetAll().Where(x => x.Email == request.Email).FirstOrDefault();

            var manager = await _userRepository.GetAsync(request.ManagerId);
            if (manager == null || manager.IsDeleted)
                return new Response<Invitation>("The managerId that you use to invite doesnt exist");

            if (guest == null || guest.IsDeleted)
                return new Response<Invitation>("The guest that you try to invite doesnt exist");

            if (guest?.Id == manager.Id)
                return new Response<Invitation>("Cannot send an invite to yourself");

            var existingInvitations = _invitationRepository.GetAll().Where(x => x.ManagerId == request.ManagerId && x.Email == request.Email && !x.IsDeleted).FirstOrDefault();
            if (existingInvitations != null && !existingInvitations.Status && !existingInvitations.IsDeleted)
                return new Response<Invitation>("Cannot send another invitation to this guest user because you have an existing one");

            request.IsDeleted = false;
            request.Status = false;
            request.ManagerId = manager.Id;
            request.GuestId = guest.Id;

            try
            {
                await _invitationRepository.InsertAsync(request);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new Response<Invitation>(ex.Message);
            }

            return new Response<Invitation>(request);
        }

        public async Task<bool> DeleteInvitation(int invitationId)
        {
            try
            {
                var invitation = await _invitationRepository.GetAsync(invitationId);
                if (invitation == null || invitation.IsDeleted)
                    return false;

                invitation.IsDeleted = true;
                await _invitationRepository.UpdateAsync(invitation);
                await _unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Invitation>> Search(int? managerId = null, int? guestId = null)
        {
            var query = _invitationRepository.GetAll().Where(q => !q.IsDeleted);

            if (managerId != null)
                query = query.Where(q => q.ManagerId == managerId);

            if (guestId != null)
                query = query.Where(q => q.GuestId == guestId);

            return await query.ToListAsync();
        }
    }
}
