using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrac.API.Domain.DataObjects.Url;
using Montrac.API.Domain.Models;
using Montrac.API.Domain.Services;

namespace Montrac.api.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/url")]
    public class UrlController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUrlService _urlService;

        public UrlController(IMapper mapper, IUrlService urlService)
        {
            _mapper = mapper;
            _urlService = urlService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewUrl resource)
        {
            var result = await _urlService.CreateUrl(_mapper.Map<NewUrl, Url>(resource));

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpGet]
        public async Task<IEnumerable<NewUrl>> Search([FromQuery] int? urlId, [FromQuery] int? userId)
        {
            var urls =  await _urlService.Search(urlId, userId);
            return _mapper.Map<IEnumerable<Url>, IEnumerable<NewUrl>>(urls);
        }
    }
}
