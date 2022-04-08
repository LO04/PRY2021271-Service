using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrac.Api.Extensions;
using Montrac.Domain.DataObjects;
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
    [Route("api/program")]
    public class ProgramController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly IMapper Mapper;
        private readonly IProgramService ProgramService;

        public ProgramController(IUserService userService, IMapper mapper, IProgramService programService)
        {
            UserService = userService;
            Mapper = mapper;
            ProgramService = programService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewProgram resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await ProgramService.CreateProgram(Mapper.Map<NewProgram, Program>(resource));

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpDelete("programId")]
        public async Task<IActionResult> DeleteAsync(int programId)
        {
            var result = await ProgramService.DeleteProgram(programId);

            if (result != true)
                return BadRequest("Program couldnt be deleted");

            return Ok(true);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] NewProgram program)
        {
            var result = await ProgramService.EditProgram(Mapper.Map<NewProgram, Program>(program));
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Resource);
        }

        [HttpGet]
        public async Task<IEnumerable<NewProgram>> Search([FromQuery] int? programId, [FromQuery] int? userId)
        {
            var programs = await ProgramService.Search(programId, userId);
            return Mapper.Map<IEnumerable<Program>, IEnumerable<NewProgram>>(programs);
        }
    }
}
