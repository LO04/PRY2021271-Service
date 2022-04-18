using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Montrac.Api.Authentication;
using Montrac.Api.DataObjects.Authentication;
using Swashbuckle.AspNetCore.Annotations;
using Montrac.Api.Extensions;
using Montrac.Domain.Models;
using Montrac.Domain.Services;
using Montrac.api.DataObjects.User;
using Microsoft.AspNetCore.Http;

namespace Montrac.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly IMapper Mapper;
        private readonly IAuthenticationService AuthenticationService;

        public UserController(IUserService userService, IMapper mapper, IAuthenticationService authenticationService)
        {
            UserService = userService;
            Mapper = mapper;
            AuthenticationService = authenticationService;
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest request)
        {
            var response = await AuthenticationService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Invalid Email or Password" });

            return Ok(response);
        }

        [HttpGet]
        public async Task<IEnumerable<BasicUserView>> Search([FromQuery]string email, [FromQuery] int? managerId, [FromQuery] int? userId)
        {
            var users = await UserService.Search(email, managerId, userId);
            return Mapper.Map<IEnumerable<User>, IEnumerable<BasicUserView>>(users);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RegisterUser resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var user = Mapper.Map<RegisterUser, User>(resource);
            var result = await UserService.CreateUser(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = Mapper.Map<User, BasicUserView>(result.Resource);
            return Ok(userResource);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] BasicUserView user)
        {
            var result = await UserService.EditUser(Mapper.Map<BasicUserView, User>(user));
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Resource);
        }
        
        [HttpDelete("userId")]
        public async Task<IActionResult> DeleteAsync(int userId)
        {
            var result = await UserService.DeleteUser(userId);

            if (result != true)
                return BadRequest("User couldnt be deleted");

            return Ok(true);
        }
    }
}