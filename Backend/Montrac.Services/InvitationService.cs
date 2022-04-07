using Montrac.Domain.DataObjects.Invitation;
using Montrac.Domain.Models;
using Montrac.Domain.Repository;
using Montrac.Domain.Response;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Montrac.api.DataObjects.User;

namespace Montrac.Domain.Services
{
    public class InvitationService : IInvitationService
    {
        private readonly IRepository<InvitationRequest> InvitationRepository;
        private readonly IRepository<User> UserRepository;
        private readonly IUnitOfWork UnitOfWork;

        public InvitationService(IRepository<InvitationRequest> invitationRepository, IRepository<User> userRepository,  IUnitOfWork unitOfWork)
        {
            InvitationRepository = invitationRepository;
            UserRepository = userRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> AcceptInvitation(int invitationId, int userId, bool accept)
        {
            try
            {
                var invitation = await InvitationRepository.GetAsync(invitationId);
                if (invitation == null)
                    return false;

                var user = await UserRepository.GetAsync(userId);
                if (user == null || invitation.GuestId != user.Id)
                    return false;

                if (accept)
                {
                    //if the guest accept the invitation, its updated, otherwise its deleted.
                    invitation.IsAccepted = true;
                    await InvitationRepository.UpdateAsync(invitation);
                }
                else
                {
                    await InvitationRepository.DeleteAsync(invitation);
                }

                await UnitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Response<InvitationRequest>> CreateInvitation(InvitationRequest request)
        {
            var guest = await UserRepository.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (guest == null)
                return new Response<InvitationRequest>("The email that you are trying to invite doesnt exist");

            var manager = await UserRepository.GetAsync(request.ManagerId);
            if (manager == null)
                return new Response<InvitationRequest>("The managerId that you use to invite doesnt exist");

            var basicManager = new User()
            {
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                Email = manager.Email
            };

            var basiGuest = new User()
            {
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email
            };

            var guestUser = new GuestUsers()
            {
                Email = request.Email,
                FullName = request.FullName
            };

            manager.GuestUsers.Add(guestUser);
            request.Manager = basicManager;
            request.Guest = basiGuest;

            await InvitationRepository.InsertAsync(request);
            await UserRepository.UpdateAsync(manager);
            await UnitOfWork.CompleteAsync();

            return new Response<InvitationRequest>(request);
        }

        public async Task<bool> DeleteInvitations(int invitationId)
        {
            try
            {
                var invitation = await InvitationRepository.GetAsync(invitationId);
                if (invitation == null)
                    return false;

                await InvitationRepository.DeleteAsync(invitation);
                await UnitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<InvitationRequest>> Search(int? managerId = null, int? guestId = null)
        {
            var query = InvitationRepository.GetAll();

            if (managerId != null)
                query = query.Where(q => q.ManagerId == managerId);

            if (guestId != null)
                query = query.Where(q => q.GuestId == guestId);

            return await query
                .Include(x => x.Guest)
                .Include(x => x.Manager)
                .ToListAsync();
        }
    }
}
