using Microsoft.EntityFrameworkCore;
using Montrac.API.Domain.Models;
using Montrac.API.Domain.Repository;
using Montrac.API.Domain.Response;
using Montrac.API.Domain.Services;

namespace Montrac.API.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IRepository<Domain.Models.Program> _programRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ProgramService(IRepository<Domain.Models.Program> programRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _programRepository = programRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Domain.Models.Program>> CreateProgram(Domain.Models.Program program)
        {
            if (await _userRepository.CountAsync(u => u.Id == program.UserId && u.IsDeleted) > 0)
                return new Response<Domain.Models.Program>("This user does not exist");

            if (string.IsNullOrEmpty(program.Description))
                return new Response<Domain.Models.Program>("Description is empty");

            try
            {
                await _programRepository.InsertAsync(program);
                await _unitOfWork.CompleteAsync();
            }
            catch(Exception ex)
            {
                return new Response<Domain.Models.Program>(ex.Message);
            }

            return new Response<Domain.Models.Program>(program);
        }

        public async Task<IEnumerable<Domain.Models.Program>> Search(int? programId = null, int? userId = null)
        {
            var query = _programRepository.GetAll();

            if (programId != null)
                query = query.Where(q => q.Id == programId);

            if (userId != null)
                query = query.Where(q => q.UserId == userId);

            return await query.ToListAsync();
        }
    }
}
