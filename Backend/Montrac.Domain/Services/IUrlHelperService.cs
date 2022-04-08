using Montrac.Domain.DataObjects.Url;
using Montrac.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.Services
{
    public interface IUrlHelperService
    {
        Task<List<Url>> ParseUrls(List<UrlReceived> urlReceiveds);
    }
}
