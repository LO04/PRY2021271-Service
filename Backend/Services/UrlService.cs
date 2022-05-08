using Microsoft.EntityFrameworkCore;
using Montrac.API.Domain.Models;
using Montrac.API.Domain.Repository;
using Montrac.API.Domain.Response;
using Montrac.API.Domain.Services;

namespace Montrac.Services
{
    public class UrlService : IUrlService
    {
        private readonly IRepository<Url> _urlRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UrlService(IRepository<Url> urlRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _urlRepository = urlRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Url>> CreateUrl(Url url)
        {
            if (await _userRepository.CountAsync(u => u.Id == url.UserId && u.IsDeleted) > 0)
                return new Response<Url>("User doesnt exist");

            if (string.IsNullOrEmpty(url.Uri))
                return new Response<Url>("Uri is missing");

            try
            {
                await _urlRepository.InsertAsync(url);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new Response<Url>($"An error occurred while creating url: {ex.Message}");
            }
            return new Response<Url>(url);
        }

        public async Task<IEnumerable<Url>> Search(int? urlId = null, int? userId = null)
        {
            var query = _urlRepository.GetAll();

            if (urlId != null)
                query = query.Where(q => q.Id == urlId);

            if (userId != null)
                query = query.Where(q => q.UserId == userId);

            return await query.ToListAsync();
        }
    }
}
