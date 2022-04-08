using Montrac.Domain.Models;
using Montrac.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.Services
{
    public interface IAreaService
    {
        //Task<IEnumerable<Area>> Search(int? managerId = null, int? areaId = null);
        Task<Response<Area>> CreateArea(Area area);
        //Task<Response<Area>> EditArea(Area area, int areaId);
        Task<bool> DeleteArea(int areaId);
    }
}
