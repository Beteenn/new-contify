﻿using Contify.Application.DTO;
using Contify.Application.Interfaces;
using Contify.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Contify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            var result = await _userAppService.CreateUser(userDto);

            return ResultRequest(result);
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(TokenViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _userAppService.Login(loginDto);

            return ResultRequest(result);
        }
    }
}
