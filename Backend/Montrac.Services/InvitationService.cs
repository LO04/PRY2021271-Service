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

        public InvitationService(IRepository<InvitationRequest> invitationRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
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
                //if the invited user isnt the actual user
                if (user == null || invitation.GuestId == user.Id)
                    return false;

                if (accept && !invitation.Status)
                {
                    //if the guest accept the invitation, its updated, otherwise its deleted.
                    //and to keep history of invitations only change status to accepted instead of delete the invitation
                    invitation.Status = true;
                    await InvitationRepository.UpdateAsync(invitation);

                    //add invited user to the group of workers for the manager
                    var manager = await UserRepository.GetAsync(invitation.ManagerId);
                    manager.Users.Add(user);
                    await UserRepository.UpdateAsync(manager);

                    //update worker
                    user.Manager = new GuestUsers()
                    {
                        Id = manager.Id,
                        Email = manager.Email,
                        FullName = manager.FirstName + ' ' + manager.LastName
                    };
                    user.ManagerId = manager.Id;
                    await UserRepository.UpdateAsync(user);
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
            var guest = UserRepository.GetAll().Where(x => x.Email == request.Email).FirstOrDefault();

            var manager = await UserRepository.GetAsync(request.ManagerId);
            if (manager == null)
                return new Response<InvitationRequest>("The managerId that you use to invite doesnt exist");

            if (guest == null)
                return new Response<InvitationRequest>("The guest that you try to invite doesnt exist");

            if (guest?.Id == manager.Id)
                return new Response<InvitationRequest>("Cannot send an invite to yourself");

            var basicManager = new GuestUsers()
            {
                Id = manager.Id,
                FullName = manager.FirstName + ' ' + manager.LastName,
                Email = manager.Email
            };

            var basicGuest = new GuestUsers()
            {
                Id = guest.Id,
                FullName = guest.FirstName + ' ' + guest.LastName,
                Email = guest.Email
            };

            request.Status = false;
            request.Manager = basicManager;
            request.Guest = basicGuest;
            manager.Invitations.Add(request);

            try
            {
                await UserRepository.UpdateAsync(manager);
                await InvitationRepository.InsertAsync(request);
                await UnitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new Response<InvitationRequest>(ex.Message);
            }

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
