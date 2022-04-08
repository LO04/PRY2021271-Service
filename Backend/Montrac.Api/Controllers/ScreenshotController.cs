using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrac.Api.Extensions;
using Montrac.Domain.DataObjects.Screenshot;
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
    [Route("api/screenshot")]
    public class ScreenshotController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly IScreenshotService ScreenshotService;
        private readonly IMapper Mapper;
        public ScreenshotController(IUserService userService, IMapper mapper, IScreenshotService screenshotService)
        {
            UserService = userService;
            Mapper = mapper;
            ScreenshotService = screenshotService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewScreenshot screenshot)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await ScreenshotService.CreateScreenshot(Mapper.Map<NewScreenshot, Screenshot>(screenshot));

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpDelete("screenshotId")]
        public async Task<IActionResult> DeleteAsync(int screenshotId)
        {
            var result = await ScreenshotService.DeleteScreenshot(screenshotId);

            if (result != true)
                return BadRequest("Screenshot couldnt be deleted");

            return Ok(true);
        }

        [HttpGet]
        public async Task<IEnumerable<NewScreenshot>> Search([FromQuery] int? userId, [FromQuery] int? screenshotId)
        {
            var screenshots = await ScreenshotService.Search(userId, screenshotId);
            return Mapper.Map<IEnumerable<Screenshot>, IEnumerable<NewScreenshot>>(screenshots);
        }
    }
}
