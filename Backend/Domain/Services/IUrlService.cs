using Montrac.API.Domain.Models;
using Montrac.API.Domain.Response;

namespace Montrac.API.Domain.Services
{
    public interface IUrlService
    {
        Task<IEnumerable<Url>> Search(int? urlId = null, int? userId = null);
        Task<Response<Url>> CreateUrl(Url url);
    }
}
