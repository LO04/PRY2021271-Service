using HistorialNavegación.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistorialNavegación.Services.Interfaces
{
    public interface IUrlService
    {
        Task<dynamic> SendUrl(UrlRequest request);
    }
}
