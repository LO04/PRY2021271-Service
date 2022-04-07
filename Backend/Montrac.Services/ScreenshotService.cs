using Microsoft.EntityFrameworkCore;
using Montrac.Domain.Models;
using Montrac.Domain.Repository;
using Montrac.Domain.Response;
using Montrac.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Services
{
    public class ScreenshotService : IScreenshotService
    {
        private readonly IRepository<Screenshot> DetailRepository;
        private readonly IRepository<User> UserRepository;
        private readonly IUnitOfWork UnitOfWork;

        public ScreenshotService(IRepository<Screenshot> detailRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            DetailRepository = detailRepository;
            UserRepository = userRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<Response<Screenshot>> CreateScreenshot(Screenshot detail)
        {
            var user = await UserRepository.GetAsync(detail.User.Id);

            if (user == null || user.IsDeleted)
                return new Response<Screenshot>("This user does not exist");

            var result = await DetailRepository.InsertAsync(detail);

            await UnitOfWork.CompleteAsync();
            return new Response<Screenshot>(result);
        }

        public async Task<bool> DeleteScreenshot(int detailId)
        {
            try
            {
                var detail = await DetailRepository.GetAsync(detailId);
                if (detail == null)
                    return false;

                await DetailRepository.DeleteAsync(detail);
                await UnitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Response<Screenshot>> EditScreenshot(Screenshot detail, int detailId)
        {
            try
            {
                if (await DetailRepository.GetAsync(detailId) == null)
                    return new Response<Screenshot>($"This detail does not exist");

                detail.UpdatedAt = DateTime.Now;
                await DetailRepository.UpdateAsync(detail);
                await UnitOfWork.CompleteAsync();

                return new Response<Screenshot>(detail);
            }
            catch (Exception ex)
            {
                return new Response<Screenshot>($"An error occurred while updating the detail: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Screenshot>> Search(int? userId = null, int? screenshotId = null)
        {
            var query = DetailRepository.GetAll();

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
