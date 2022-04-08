//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Montrac.Api.Extensions;
//using Montrac.Domain.Models;
//using Montrac.Domain.Services;
//using Montrac.Domain.DataObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Montrac.api.Controllers
//{
//    [Authorize]
//    [ApiController]
//    [Produces("application/json")]
//    [Route("api/area")]
//    public class AreaController : ControllerBase
//    {
//        private readonly IAreaService AreaService;
//        private readonly IUserService UserService;
//        private readonly IMapper Mapper;
//        public AreaController(IUserService userService, IMapper mapper, IAreaService areaService)
//        {
//            UserService = userService;
//            Mapper = mapper;
//            AreaService = areaService;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public async Task<IActionResult> PostAsync([FromBody] RegisterArea area)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState.GetErrorMessages());
//            var result = await AreaService.CreateArea(Mapper.Map<RegisterArea, Area>(area));

//            if (!result.Success)
//                return BadRequest(result.Message);

//            return Ok(result.Resource);
//        }

//        [HttpDelete("areaId")]
//        public async Task<IActionResult> DeleteAsync(int areaId)
//        {
//            var result = await AreaService.DeleteArea(areaId);

//            if (result != true)
//                return BadRequest("Area couldnt be deleted");

//            return Ok(true);
//        }

//        //[HttpPut("{areaId:int}")]
//        //public async Task<IActionResult> PutAsync([FromBody] NewArea area, int areaId)
//        //{
//        //    var result = await AreaService.EditArea(Mapper.Map<NewArea, Area>(area), areaId);
//        //    if (!result.Success)
//        //        return BadRequest(result.Message);
//        //    return Ok(result.Resource);
//        //}
//        //
//        //[HttpGet]
//        //public async Task<IEnumerable<NewArea>> Search([FromQuery] int? managerId, [FromQuery] int? areaId)
//        //{
//        //    var areas = await AreaService.Search(managerId, areaId);
//        //    return Mapper.Map<IEnumerable<Area>, IEnumerable<NewArea>>(areas);
//        //}
//    }
//}
