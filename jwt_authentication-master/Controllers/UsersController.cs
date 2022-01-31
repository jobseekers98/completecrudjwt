﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELfile;
using Servicefile.IRepository.IUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jwt_Authentication.Controllers
{
    [ApiController]
    [Route("user")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("GetUserDetails")]
        public async Task<List<UserModel>> GetUserDetail(int? userId)
        {
            return await _userService.GetUserDetail(userId);
        }

        [HttpPost]
        [Route("AddUpdateUser")]
        public async Task<int> AddUpdateUser(UserModel user)
        {
            int result = await _userService.AddUpdateUser(user);
            return result;
        }

        [HttpDelete]
        [Route("AddUpdateUser")]
        public async Task<int> DeleteUser(int userId)
        {
            int result = await _userService.DeleteUser(userId);
            return result;
        }
    }
}
