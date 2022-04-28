using Microsoft.EntityFrameworkCore;
using Montrac.Domain.Models;
using Montrac.Domain.Repository;
using Montrac.Domain.Response;
using Montrac.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IRepository<Program> ProgramRepository;
        private readonly IRepository<User> UserRepository;
        private readonly IUnitOfWork UnitOfWork;


        public ProgramService(IRepository<Program> programRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            ProgramRepository = programRepository;
            UserRepository = userRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<Response<Program>> CreateProgram(Program program)
        {
            if (string.IsNullOrEmpty(program.Description))
                return new Response<Program>("Description is empty");

            await ProgramRepository.InsertAsync(program);
            await UnitOfWork.CompleteAsync();

            return new Response<Program>(program);
        }

        public async Task<bool> DeleteProgram(int programId)
        {
            try
            {
                var program = await ProgramRepository.GetAsync(programId);
                if (program == null)
                    return false;

                await ProgramRepository.DeleteAsync(program);
                await UnitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Response<Program>> EditProgram(Program program)
        {
            try
            {
                if (await ProgramRepository.GetAsync(program.Id) == null)
                    return new Response<Program>($"The program does not exist");

                program.UpdatedAt = DateTime.Now;
                await ProgramRepository.UpdateAsync(program);
                await UnitOfWork.CompleteAsync();

                return new Response<Program>(program);
            }
            catch (Exception ex)
            {
                return new Response<Program>($"An error occurred while updating the program: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Program>> Search(int? programId = null, int? userId = null)
        {
            var query = ProgramRepository.GetAll();

            if (programId != null)
                query = query.Where(q => q.Id == programId);

            if (userId != null)
                query = query.Where(q => q.UserId == userId);

            return await query
                .Include(x => x.User)                
                .ToListAsync();
        }
    }
}
