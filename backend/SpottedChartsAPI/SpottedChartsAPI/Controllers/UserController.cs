﻿using Microsoft.AspNetCore.Mvc;
using SpottedChartsAPIDomain.DTOs;
using SpottedChartsAPIDomain.Interfaces;

namespace SpottedChartsAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/user/")]
        public Task<UserDTO> UserAuth([FromBody] UserDTO user)
        {
            try
            {
                var returnUser = _userService.UserAuth(user);
                return Task.FromResult(returnUser);
            }
            catch (Exception ex)
            {
                return Task.FromException<UserDTO>(ex);
            }
        }

        [HttpGet]
        [Route("/user/{spotifyUserId}")]
        public UserDTO GetUserById(string spotifyUserId)
        {
            return _userService.GetUser(spotifyUserId);
        }
    }
}

