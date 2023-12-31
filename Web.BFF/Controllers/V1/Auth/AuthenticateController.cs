﻿using Microsoft.AspNetCore.Mvc;
using Web.Core.DTOs.Auth;
using Web.Core.DTOs.Response;
using Web.Core.DTOs.User;
using Web.Core.Interfaces.Auth;
using Web.Core.Interfaces.Response;

namespace Web.BFF.Controllers.V1.Auth
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthenticateController : BaseApiController
    {
        private readonly IAuthService _authService;
        private readonly IResponseService _responseService;

        public AuthenticateController(
            IAuthService authService,
            IResponseService responseService)
        {
            _authService = authService;
            _responseService = responseService;
        }

        /// <summary>
        /// Get auth token
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(ApiResponseDto<TokenDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseDto<ExceptionDto>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            return Ok(_responseService.CreateResponse(await _authService.LoginAsync(loginDto)));
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(ApiResponseDto<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseDto<ExceptionDto>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            return Ok(_responseService.CreateResponse(await _authService.RegisterAsync(registerDto)));
        }
    }
}