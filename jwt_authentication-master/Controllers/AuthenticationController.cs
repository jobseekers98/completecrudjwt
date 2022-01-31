using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELfile;
using MODELfile.Authenticate;
using Servicefile.IRepository.IAuthentication;
using Servicefile.IRepository.IUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt_Authentication.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _IauthenticationService;
        public AuthenticationController(IAuthenticationService IauthenticationService)
        {
            _IauthenticationService = IauthenticationService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<UserModel> Authenticate(AuthenticateRequest model)
        {
            UserModel response = await _IauthenticationService.Authenticate(model);
            if (response != null)
            {
                response.Token = _IauthenticationService.GenerateToken(response);
            }
            else
            {
                //return BadRequest(new { message = "Username or password is incorrect" });
                throw new Exception("Username or password is incorrect");
            }
            return response;
        }
    }
}
