using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Application.Common;
using StudentManagementSystem.Application.RequestModels;
using StudentManagementSystem.Application.Services;

namespace StudentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public LoginAuthController(ITokenService tokenService)
        {
            this._tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        #region Generate TOken

        [HttpPost("Login")]
        public async Task<ActionResult<ResponseModel>> Login(LoginRequestDto request)
        {
            // 🔴 Hardcoded user (for assignment simplicity)
            if (request.Username == "admin" && request.Password == "password")
            {
                var token = _tokenService.GenerateToken(request.Username);

                return Ok(new LoginResponseDto
                {
                    Token = token
                });
            }
            return Unauthorized("Invalid credentials");
        }
        #endregion
    }
}
