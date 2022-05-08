using Montrac.API.Domain.Response;

namespace Montrac.API.Domain.Services
{
    public interface IProgramService
    {
        Task<IEnumerable<Models.Program>> Search(int? programId = null, int? userId = null);
        Task<Response<Models.Program>> CreateProgram(Models.Program program);
    }
}
