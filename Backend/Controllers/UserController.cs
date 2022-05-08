using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrac.API.Authentication;
using Montrac.API.DataObjects.User;
using Montrac.API.Domain.DataObjects.Authentication;
using Montrac.API.Domain.DataObjects.User;
using Montrac.API.Domain.Models;
using Montrac.API.Domain.Services;

namespace Montrac.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public UserController(IUserService userService, IMapper mapper, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _mapper = mapper;
            _authenticationService = authenticationService;
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest request)
        {
            var response = await _authenticationService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Invalid Email or Password" });

            return Ok(response);
        }

        [HttpGet]
        public async Task<IEnumerable<BasicUserView>> Search([FromQuery]string? email, [FromQuery] int? userId)
        {
            var users = await _userService.Search(email, userId);
            return _mapper.Map<IEnumerable<User>, IEnumerable<BasicUserView>>(users);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RegisterUser resource)
        {
            var user = _mapper.Map<RegisterUser, User>(resource);
            var result = await _userService.CreateUser(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, BasicUserView>(result.Resource);
            return Ok(userResource);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] BasicUserView user)
        {
            var result = await _userService.EditUser(_mapper.Map<BasicUserView, User>(user));

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }
        
        [HttpDelete("userId")]
        public async Task<IActionResult> DeleteAsync(int userId)
        {
            var result = await _userService.DeleteUser(userId);

            if (result != true)
                return BadRequest("User couldnt be deleted");

            return Ok(true);
        }
    }
}