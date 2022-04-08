using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Montrac.api.DataObjects.User;
using Montrac.Domain.Models;
using Montrac.Domain.Repository;
using Montrac.Domain.Response;
using Montrac.Domain.Services;

namespace Montrac.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> UserRepository;
        private readonly IUnitOfWork UnitOfWork;

        public UserService(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            UserRepository = userRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<Response<User>> CreateUser(User user)
        {
            if (user.Email == null)
                return new Response<User>("Email is empty");

            if (user.Password == null)
                return new Response<User>("Password is empty");

            if (await UserRepository.CountAsync(u => u.Email == user.Email) > 0)
                return new Response<User>("This email is already being used by another account");

            if (await UserRepository.CountAsync(u => u.Identification == user.Identification) > 0)
                return new Response<User>("This identification is already being used by another account");

            if (await UserRepository.CountAsync(u => u.PhoneNumber == user.PhoneNumber) > 0)
                return new Response<User>("This phone is already being used by another account");

            await UserRepository.InsertAsync(user);
            await UnitOfWork.CompleteAsync();

            return new Response<User>(user);
        }

        public async Task<Response<User>> EditUser(User user)
        {
            try
            {
                if (await UserRepository.GetAsync(user.Id) == null)
                    return new Response<User>($"The user does not exist");

                user.UpdatedAt = DateTime.Now;
                await UserRepository.UpdateAsync(user);
                await UnitOfWork.CompleteAsync();

                return new Response<User>(user);
            }
            catch (Exception ex)
            {
                return new Response<User>($"An error occurred while updating the User: {ex.Message}");
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var user = await UserRepository.GetAsync(userId);
                if (user == null)
                    return false;

                await UserRepository.DeleteAsync(user);
                await UnitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> Search(int? managerId = null, int? userId = null)
        {
            var query = UserRepository.GetAll();

            if (managerId != null)
                query = query.Where(q => q.Manager.Id == managerId);

            if (userId != null)
                query = query.Where(q => q.Id == userId);

            return await
                query
                .Include(x => x.Programs)
                .Include(x => x.Manager)
                .Include(x => x.Invitations)
                .Include(x => x.Screenshots)
                .Include(x => x.Urls)
                .ToListAsync();
        }
    }
}