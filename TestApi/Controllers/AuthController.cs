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
        public IActionResult Login([FromBody] UserCredential userCredential)
        {
          
                var token = _jwtTokenManager.Authenticate(userCredential.User, userCredential.PassWord);
                return Ok(token);
            }
       
        }
    }

