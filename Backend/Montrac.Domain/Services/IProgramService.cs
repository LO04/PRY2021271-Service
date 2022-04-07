using Montrac.Domain.Models;
using Montrac.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.Services
{
    public interface IProgramService
    {
        Task<IEnumerable<Program>> Search(int? programId = null, int? userId = null);
        Task<Response<Program>> CreateProgram(Program program);
        Task<Response<Program>> EditProgram(Program program, int programId);
        Task<bool> DeleteProgram(int programId);
    }
}
