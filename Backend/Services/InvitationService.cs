using Microsoft.EntityFrameworkCore;
using Montrac.API.Domain.Services;
using Montrac.API.Domain.Repository;
using Montrac.API.Domain.Models;
using Montrac.API.Domain.Response;
using System.Net.Mail;

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

                if (invitation.GuestId == null || invitation.GuestId == 0)
                {
                    invitation.GuestId = userId;
                }

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
            var invitedUser = _userRepository.GetAll().Where(x => x.Email == request.Email)?.FirstOrDefault();

            var manager = await _userRepository.GetAsync(request.ManagerId);
            if (manager == null || manager.IsDeleted)
                return new Response<Invitation>("The managerId that you use to invite doesnt exist");

            if (invitedUser != null && invitedUser?.Id == manager.Id)
                return new Response<Invitation>("Cannot send an invite to yourself");

            var existingInvitation = _invitationRepository.GetAll().Where(x => x.ManagerId == request.ManagerId && x.Email == request.Email && !x.IsDeleted).FirstOrDefault();
            if (existingInvitation != null && !existingInvitation.Status && !existingInvitation.IsDeleted)
                return new Response<Invitation>("Cannot send another invitation to this guest user because you have an existing one");

            if (existingInvitation != null && existingInvitation.Status && !existingInvitation.IsDeleted)
                return new Response<Invitation>("Cannot send an invitation to this guest user because its already on your team");

            var lastUser = _userRepository.GetAll().ToList().LastOrDefault();
            var newUser = new User()
            {
                FirstName = request.FullName,
                Email = request.Email,
                Password = "password",
                PhoneNumber = " ",
                LastName = " ",
                ManagerId = request.ManagerId
            };

            try
            {
                await _userRepository.InsertAsync(newUser);

                request.IsDeleted = false;
                request.Status = false;
                request.ManagerId = manager.Id;

                await SendEmail(request.Email, manager.FirstName);
                await _invitationRepository.InsertOrUpdateAsync(request);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new Response<Invitation>(ex.Message);
            }

            return new Response<Invitation>(request);
        }

        public async Task SendEmail(string email, string managerName)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("montrac2022@gmail.com");
            mail.To.Add(email);
            mail.Subject = $"Invitación para el grupo de trabajo de {managerName}";
            mail.Body = $"<div><h2>{managerName} lo ha invitado a unirse a su nuevo grupo de trabajo</h2>" +
                $"<h4>Puede descargar la aplicación desktop aqui: https://blobmontracstorage1.blob.core.windows.net/fileupload/Setup.msi</h4>" +
            $"<h4>Puede ingresar a esta página web para ver los detalles de su trabajo: https://web-delta-dun.vercel.app/#/login</h4>" +
                $"<h4>Las credenciales de acceso que le han sido brindadas son:</h4><h5><b>Correo:{email}</h5><h5> Contraseña: password</b></h5></div>";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("montrac2022@gmail.com", "bazozfvbmrnoftis");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(mail);
        }

        public async Task<bool> ConfirmPayment(string name, string email, string suscription)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("montrac2022@gmail.com");
                mail.To.Add(email);
                mail.Subject = $"Confirmación de pago aceptada";
                mail.Body = $"<div><h2>{name} se ha confirmado su pago por una suscripción {suscription} para utilizar la aplicación de Montrac</h2>" +
                    $"<h4>Puede descargar la aplicación desktop aqui:https://blobmontracstorage1.blob.core.windows.net/fileupload/Setup.msi</h4>" +
                    $"<h4>Puede ingresar a esta página web para comenzar a invitar a sus trabajadores: https://web-delta-dun.vercel.app/#/login</h4>" +
                    $"<h4>Las credenciales de acceso que le han sido brindadas son:</h4><h5><b>Correo:admin@montrac.com</h5><h5> Contraseña: Admin@123</b></h5></div>";
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("montrac2022@gmail.com", "bazozfvbmrnoftis");
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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

        public async Task<IEnumerable<Invitation>> Search(int? managerId = null, int? guestId = null, string? guestEmail = null)
        {
            var query = _invitationRepository.GetAll().Where(q => !q.IsDeleted);

            if (managerId != null)
                query = query.Where(q => q.ManagerId == managerId);

            if (guestId != null)
                query = query.Where(q => q.GuestId == guestId);

            if (guestEmail != null)
                query = query.Where(q => q.Email == guestEmail);

            return await query.ToListAsync();
        }
    }
}
