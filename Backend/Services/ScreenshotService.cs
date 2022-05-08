using Microsoft.EntityFrameworkCore;
using Montrac.API.Domain.Models;
using Montrac.API.Domain.Repository;
using Montrac.API.Domain.Response;
using Montrac.API.Domain.Services;

namespace Montrac.Services
{
    public class ScreenshotService : IScreenshotService
    {
        private readonly IRepository<Screenshot> _screenshotRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ScreenshotService(IRepository<Screenshot> screenshotRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _screenshotRepository = screenshotRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Screenshot>> CreateScreenshot(Screenshot screenshot)
        {
            if (await _userRepository.CountAsync(u => u.Id == screenshot.UserId && u.IsDeleted) > 0)
                return new Response<Screenshot>("This user does not exist");

            if (string.IsNullOrEmpty(screenshot.Blob))
                return new Response<Screenshot>("Blob is empty");

            try
            {
                await _screenshotRepository.InsertAsync(screenshot);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new Response<Screenshot>(ex.Message);
            }

            return new Response<Screenshot>(screenshot);
        }

        public async Task<IEnumerable<Screenshot>> Search(int? screenshotId = null, int? userId = null)
        {
            var query = _screenshotRepository.GetAll();

            if (userId != null)
                query = query.Where(q => q.UserId == userId);

            if (screenshotId != null)
                query = query.Where(q => q.Id == screenshotId);

            return await query
                .Include(x => x.User)
                .ToListAsync();
        }
    }
}
