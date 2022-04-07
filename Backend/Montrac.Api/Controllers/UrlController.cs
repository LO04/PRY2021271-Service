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
    [Route("api/url")]
    public class UrlController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly IMapper Mapper;
        private readonly IUrlService UrlService;

        public UrlController(IUserService userService, IMapper mapper, IUrlService urlService)
        {
            UserService = userService;
            Mapper = mapper;
            UrlService = urlService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Url resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await UrlService.CreateUrl(resource);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpDelete("urlId")]
        public async Task<IActionResult> DeleteAsync(int urlId)
        {
            var result = await UrlService.DeleteUrl(urlId);

            if (result != true)
                return BadRequest("Url couldnt be deleted");

            return Ok(true);
        }

        [HttpPut("{urlId:int}")]
        public async Task<IActionResult> PutAsync([FromBody] Url url, int urlId)
        {
            var result = await UrlService.EditUrl(url, urlId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Resource);
        }

        [HttpGet]
        public async Task<IEnumerable<Url>> Search([FromQuery] int? urlId)
        {
            return await UrlService.Search(urlId);
        }
    }
}
