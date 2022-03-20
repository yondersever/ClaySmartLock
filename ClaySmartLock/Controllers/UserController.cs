using ClaySmartLock.Model.Contract.User;
using ClaySmartLock.Model.Service.User;
using ClaySmartLock.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaySmartLock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticateUserResponse>> Authenticate(AuthenticateUserRequest request)
        {
            AuthenticateUserServiceRequest serviceRequest = new AuthenticateUserServiceRequest
            {
                UserName = request.UserName,
                Password = request.Password
            };

            var response = await _userService.AuthenticateUser(serviceRequest);

            if (response == null)
                return BadRequest("Invalid credentials.");

            return Ok(response);
        }

    }
}
