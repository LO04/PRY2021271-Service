using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrac.Api.Extensions;
using Montrac.Domain.Models;
using Montrac.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Montrac.api.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/area")]
    public class AreaController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly IAreaService AreaService;
        private readonly IMapper Mapper;
        public AreaController(IUserService userService, IMapper mapper, IAreaService areaService)
        {
            UserService = userService;
            Mapper = mapper;
            AreaService = areaService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Area area)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await AreaService.CreateArea(area);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpPut("{areaId:int}")]
        public async Task<IActionResult> PutAsync([FromBody] Area area, int areaId)
        {
            var result = await AreaService.EditArea(area, areaId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Resource);
        }

        [HttpDelete("areaId")]
        public async Task<IActionResult> DeleteAsync(int areaId)
        {
            var result = await AreaService.DeleteArea(areaId);

            if (result != true)
                return BadRequest("Area couldnt be deleted");

            return Ok(true);
        }

        [HttpGet]
        public async Task<IEnumerable<Area>> Search([FromQuery] int? managerId, [FromQuery] int? areaId)
        {
            return await AreaService.Search(managerId, areaId);
        }
    }
}
