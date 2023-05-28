using System.Data;
using AutoMapper;
using Azure;
using computershopAPI.Auth;
using computershopAPI.Dtos.ProductDtos;
using computershopAPI.Dtos.UserDtos;
using computershopAPI.Services.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Response = computershopAPI.Models.Response;

namespace computershopAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var response = await _authService.DoLogin(model);

            if (response.Success == true)
            {
                return Ok(response.Data);
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _authService.UserExists(model.Username);

            if (userExists == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "error", Message = "User Already Exists" });
            }

            var result = await _authService.AddUser(model);

            if (result == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed!" });
            }

            return Ok(new Response { Status = "Success", Message = "User Created Succesfully" });
        }

    }
}
