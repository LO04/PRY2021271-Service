using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Montrac.Domain.Models;
using Montrac.Domain.Response;

namespace Montrac.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Search(int? managerId = null, int? userId = null);
        Task<Response<User>> CreateUser(User user);
        Task<Response<User>> EditUser(User user);
        Task<bool> DeleteUser(int userId);
    }
}