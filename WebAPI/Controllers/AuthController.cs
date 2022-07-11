using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {

            var userToLoginResult = _authService.Login(userForLoginDto);

            if (!userToLoginResult.Success)
            {

                return BadRequest(userToLoginResult);
            }

            var result = _authService.CreateAccessToken(userToLoginResult.Data);

            if (result.Success)
            {

                return Ok(result);
            }


            return BadRequest(result);

        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {

            var userExistsResult = _authService.UserExists(userForRegisterDto.Email);

            if (!userExistsResult.Success)
            {
                return BadRequest(userExistsResult);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);

            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
