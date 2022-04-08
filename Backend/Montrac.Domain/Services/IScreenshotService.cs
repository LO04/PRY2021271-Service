using Montrac.Domain.Models;
using Montrac.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.Services
{
    public interface IScreenshotService
    {
        Task<IEnumerable<Screenshot>> Search(int? userId = null, int? screenshotId = null);
        Task<Response<Screenshot>> CreateScreenshot(Screenshot screenshot);
        Task<bool> DeleteScreenshot(int screenshotId);
    }
}
