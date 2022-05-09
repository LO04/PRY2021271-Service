using Microsoft.EntityFrameworkCore;
using Montrac.API.Domain.Models;
using Montrac.API.Domain.Repository;
using Montrac.API.Domain.Response;
using Montrac.API.Domain.Services;

namespace Montrac.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<User>> CreateUser(User user)
        {
            if (user.Email == null)
                return new Response<User>("Email is empty");

            if (user.Password == null)
                return new Response<User>("Password is empty");

            if (await _userRepository.CountAsync(u => u.Email == user.Email && !u.IsDeleted) > 0)
                return new Response<User>("This email is already being used by another account");

            if (await _userRepository.CountAsync(u => u.Identification == user.Identification && !u.IsDeleted) > 0)
                return new Response<User>("This identification is already being used by another account");

            if (await _userRepository.CountAsync(u => u.PhoneNumber == user.PhoneNumber && !u.IsDeleted) > 0)
                return new Response<User>("This phone is already being used by another account");

            try
            {
                await _userRepository.InsertAsync(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new Response<User>($"An error occurred while creating the user: {ex.Message}");
            }

            return new Response<User>(user);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var user = await _userRepository.GetAsync(userId);
                if (user == null || user.IsDeleted)
                    return false;

                user.IsDeleted = true;
                await _userRepository.UpdateAsync(user);
                await _unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Response<User>> EditUser(User user)
        {
            var existedUser = await _userRepository.GetAsync(user.Id);
            if (existedUser == null || existedUser.IsDeleted)
                return new Response<User>("The user does not exist");

            try
            {
                existedUser.FirstName = user.FirstName ?? existedUser.FirstName;
                existedUser.LastName = user.LastName ?? existedUser.LastName;
                existedUser.Email = user.Email ?? existedUser.Email;
                existedUser.Identification = user.Identification ?? existedUser.Identification;
                existedUser.PhoneNumber = user.PhoneNumber ?? existedUser.PhoneNumber;
                existedUser.Password = user.Password ?? existedUser.Password;
                existedUser.UpdatedAt = DateTime.Now;

                var result = await _userRepository.UpdateAsync(existedUser);
                await _unitOfWork.CompleteAsync();
                return new Response<User>(result);
            }
            catch (Exception ex)
            {
                return new Response<User>($"An error occurred while updating the user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> Search(string? email, int? userId = null)
        {
            var query = _userRepository.GetAll().Where(q => !q.IsDeleted);

            if (!string.IsNullOrEmpty(email))
                query = query.Where(q => q.Email == email);

            if (userId != null)
                query = query.Where(q => q.Id == userId);

            return await query.ToListAsync();
        }
    }
}