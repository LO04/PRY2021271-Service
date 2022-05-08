using Montrac.API.Domain.Models;
using Montrac.API.Domain.Response;

namespace Montrac.API.Domain.Services
{
    public interface IScreenshotService
    {
        Task<IEnumerable<Screenshot>> Search(int? screenshotId = null, int? userId = null);
        Task<Response<Screenshot>> CreateScreenshot(Screenshot screenshot);
    }
}
