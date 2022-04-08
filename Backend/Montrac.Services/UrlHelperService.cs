using AutoMapper;
using Montrac.Domain.DataObjects.Url;
using Montrac.Domain.Models;
using Montrac.Domain.Repository;
using Montrac.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Services
{
    public class UrlHelperService : IUrlHelperService
    {
        private readonly IRepository<User> UserRepository;
        private readonly IMapper Mapper;

        public UrlHelperService(IMapper mapper, IRepository<User> userRepository)
        {
            UserRepository = userRepository;
            Mapper = mapper;
        }

        /// <summary>
        /// Given a list of objects that contains title, description and browser information about user interaction
        /// </summary>
        /// <returns>
        /// A parse list with Url object
        /// </returns>
        public async Task<List<Url>> ParseUrls(List<UrlReceived> urlReceiveds)
        {
            var resultUrls = new List<Url>();

            foreach (var url in urlReceiveds)
            {
                if (await UserRepository.GetAsync(url.UserId) != null)
                    resultUrls.Add(Mapper.Map<UrlReceived, Url>(url));
            }
            return resultUrls;
        }
    }
}
