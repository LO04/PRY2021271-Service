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
        public async Task<IActionResult> PostAsync([FromBody] Program resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await ProgramService.CreateProgram(resource);

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

        [HttpPut("{programId:int}")]
        public async Task<IActionResult> PutAsync([FromBody] Program program, int programId)
        {
            var result = await ProgramService.EditProgram(program, programId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Resource);
        }

        [HttpGet]
        public async Task<IEnumerable<Program>> Search([FromQuery] int? programId, [FromQuery] int? userId)
        {
            return await ProgramService.Search(programId, userId);
        }
    }
}
