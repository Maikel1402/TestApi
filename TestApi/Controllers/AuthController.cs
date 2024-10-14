using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestCore.Dto.Request;
using TestCore.Interfaces.Authentication;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenManager _jwtTokenManager;
        public AuthController(IJwtTokenManager jwtTokenManager)
        {
            _jwtTokenManager = jwtTokenManager;
        }
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Login([FromBody] UserCredential userCredential)
        {

            var token = await _jwtTokenManager.Authenticate(userCredential.User, userCredential.PassWord);
            if (token == "Ivalid User") return BadRequest("Usuario No válido");

            return Ok(token);
        }

    }
}

