using Microsoft.AspNetCore.Mvc;
using WebApplication8.Dtos;
using WebApplication8.Services;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var token = await _loginService.ValidateUserAsync(dto);

            if (token == null)
            {
                //return Forbid();
                return NotFound();
            }

            return Ok(token);
        }
    }
}
