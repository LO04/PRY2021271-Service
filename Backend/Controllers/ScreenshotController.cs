using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrac.API.Domain.DataObjects.Screenshot;
using Montrac.API.Domain.Models;
using Montrac.API.Domain.Services;

namespace Montrac.api.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/screenshot")]
    public class ScreenshotController : ControllerBase
    {
        private readonly IScreenshotService _screenshotService;
        private readonly IMapper _mapper;
        public ScreenshotController(IMapper mapper, IScreenshotService screenshotService)
        {
            _mapper = mapper;
            _screenshotService = screenshotService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewScreenshot screenshot)
        {
            var result = await _screenshotService.CreateScreenshot(_mapper.Map<NewScreenshot, Screenshot>(screenshot));

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpGet]
        public async Task<IEnumerable<NewScreenshot>> Search([FromQuery] int? screenshotId, [FromQuery] int? userId)
        {
            var screenshots = await _screenshotService.Search(screenshotId, userId);
            return _mapper.Map<IEnumerable<Screenshot>, IEnumerable<NewScreenshot>>(screenshots);
        }
    }
}
