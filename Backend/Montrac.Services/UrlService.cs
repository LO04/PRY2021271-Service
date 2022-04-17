using Microsoft.EntityFrameworkCore;
using Montrac.Domain.DataObjects.Url;
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
    public class UrlService : IUrlService
    {
        private readonly IRepository<Url> UrlRepository;
        private readonly IRepository<User> UserRepository;
        private readonly IUnitOfWork UnitOfWork;

        public UrlService(IRepository<Url> urlRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            UrlRepository = urlRepository;
            UserRepository = userRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<Response<List<Url>>> CreateUrlByList(List<Url> urls)
        {
            try
            {
                if (urls.Count == 0)
                    return new Response<List<Url>>("List doesnt contain elements");

                foreach (var url in urls)
                {
                    await UrlRepository.InsertAsync(url);
                    await UnitOfWork.CompleteAsync();
                }

                return new Response<List<Url>>(urls);
            }
            catch (Exception ex)
            {
                return new Response<List<Url>>($"An error occurred while creating the list of urls: {ex.Message}");
            }
        }

        public async Task<Response<Url>> CreateUrl(Url url)
        {
            if (string.IsNullOrEmpty(url.Uri))
                return new Response<Url>("Uri is missing");

            if (await UserRepository.GetAsync(url.UserId) == null)
                return new Response<Url>("User is missing");

            try
            {
                var result = await UrlRepository.InsertAsync(url);
                await UnitOfWork.CompleteAsync();
                return new Response<Url>(result);
            }
            catch (Exception ex)
            {
                return new Response<Url>($"An error occurred while creating url: {ex.Message}");
            }

        }
        public async Task<bool> DeleteUrl(int urlId)
        {
            try
            {
                var url = await UrlRepository.GetAsync(urlId);
                if (url == null)
                    return false;

                await UrlRepository.DeleteAsync(url);
                await UnitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Response<Url>> EditUrl(Url url)
        {
            try
            {
                if (await UrlRepository.GetAsync(url.Id) == null)
                    return new Response<Url>($"The url does not exist");

                url.UpdatedAt = DateTime.Now;
                await UrlRepository.UpdateAsync(url);
                await UnitOfWork.CompleteAsync();

                return new Response<Url>(url);
            }
            catch (Exception ex)
            {
                return new Response<Url>($"An error occurred while updating the url: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Url>> Search(int? urlId = null, int? userId = null)
        {
            var query = UrlRepository.GetAll();

            if (urlId != null)
                query = query.Where(q => q.Id == urlId);

            if (userId != null)
                query = query.Where(q => q.UserId == userId);

            return await
                query
                .Include(x => x.User)
                .ToListAsync();
        }
    }
}
