using Montrac.Domain.Models;
using Montrac.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.Services
{
    public interface IUrlService
    {
        Task<IEnumerable<Url>> Search(int? urlId = null);
        Task<Response<Url>> CreateUrl(Url url);
        Task<Response<Url>> EditUrl(Url url, int urlId);
        Task<bool> DeleteUrl(int urlId);
    }
}
