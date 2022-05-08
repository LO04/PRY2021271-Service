using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrac.API.Domain.DataObjects;
using Montrac.API.Domain.Services;

namespace Montrac.api.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/program")]
    public class ProgramController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProgramService _programService;

        public ProgramController(IMapper mapper, IProgramService programService)
        {
            _mapper = mapper;
            _programService = programService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewProgram resource)
        {
            var result = await _programService.CreateProgram(_mapper.Map<NewProgram, API.Domain.Models.Program>(resource));

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpGet]
        public async Task<IEnumerable<NewProgram>> Search([FromQuery] int? programId, [FromQuery] int? userId)
        {
            var programs = await _programService.Search(programId, userId);
            return _mapper.Map<IEnumerable<API.Domain.Models.Program>, IEnumerable<NewProgram>>(programs);
        }
    }
}
