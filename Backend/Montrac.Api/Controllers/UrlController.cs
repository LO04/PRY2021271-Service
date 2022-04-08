using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrac.Api.Extensions;
using Montrac.Domain.DataObjects.Url;
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
        private readonly IUrlHelperService UrlHelperService;

        public UrlController(IUserService userService, IMapper mapper, IUrlService urlService, IUrlHelperService urlHelperService)
        {
            UserService = userService;
            Mapper = mapper;
            UrlService = urlService;
            UrlHelperService = urlHelperService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewUrl resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await UrlService.CreateUrl(Mapper.Map<NewUrl, Url>(resource));

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpPost("by/list")]
        public async Task<IActionResult> PostListAsync([FromBody] List<NewUrlReceived> resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var newUrls = await UrlHelperService.ParseUrls(Mapper.Map<List<NewUrlReceived>, List<UrlReceived>>(resource));
            var result = await UrlService.CreateUrlByList(newUrls);

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

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] NewUrl url)
        {
            var result = await UrlService.EditUrl(Mapper.Map<NewUrl, Url>(url));
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Resource);
        }

        [HttpGet]
        public async Task<IEnumerable<NewUrl>> Search([FromQuery] int? urlId, [FromQuery] int? userId)
        {
            var urls =  await UrlService.Search(urlId, userId);
            return Mapper.Map<IEnumerable<Url>, IEnumerable<NewUrl>>(urls);
        }
    }
}
