using Montrac.Domain.Models;
using Montrac.Domain.Repository;
using Montrac.Domain.Response;
using Montrac.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Montrac.Services
{
    public class AreaService : IAreaService
    {
        private readonly IRepository<Area> AreaRepository;
        private readonly IRepository<User> UserRepository;
        private readonly IUnitOfWork UnitOfWork;

        public AreaService(IRepository<Area> areaRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            AreaRepository = areaRepository;
            UserRepository = userRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<Response<Area>> CreateArea(Area area)
        {
            var user = await UserRepository.GetAsync(area.ManagerId);

            if (user == null || user.IsDeleted)
                return new Response<Area>("This user does not exist");

            if (string.IsNullOrEmpty(area.Name))
                return new Response<Area>("Area name cannot be null");

            var result = await AreaRepository.InsertAsync(area);

            await UnitOfWork.CompleteAsync();
            return new Response<Area>(result);
        }

        public async Task<bool> DeleteArea(int areaId)
        {
            try
            {
                var area = await AreaRepository.GetAsync(areaId);
                if (area == null)
                    return false;

                await AreaRepository.DeleteAsync(area);
                await UnitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Response<Area>> EditArea(Area area, int areaId)
        {
            try
            {
                if (await AreaRepository.GetAsync(areaId) == null)
                    return new Response<Area>($"The area does not exist");

                area.UpdatedAt = DateTime.Now;
                await AreaRepository.UpdateAsync(area);
                await UnitOfWork.CompleteAsync();

                return new Response<Area>(area);
            }
            catch (Exception ex)
            {
                return new Response<Area>($"An error occurred while updating the area: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Area>> Search(int? managerId = null, int? areaId = null)
        {
            var query = AreaRepository.GetAll();

            if (managerId != null)
                query = query.Where(q => q.ManagerId == managerId);

            if (areaId != null)
                query = query.Where(q => q.Id == areaId);

            return await query.ToListAsync();
        }
    }
}
