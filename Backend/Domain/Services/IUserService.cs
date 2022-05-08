using Montrac.API.Domain.Models;
using Montrac.API.Domain.Response;

namespace Montrac.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Search(string email, int? userId = null);
        Task<Response<User>> CreateUser(User user);
        Task<Response<User>> EditUser(User user);
        Task<bool> DeleteUser(int userId);
    }
}