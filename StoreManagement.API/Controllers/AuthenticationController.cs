using StoreManagement.Data.DTOs;
using StoreManagement.Service.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StoreManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Logins the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO input)
        {
            return Ok(await _service.Login(input));
        }

        /// <summary>
        /// Logins the specified refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("GenerateNewToken")]
        public async Task<IActionResult> Login(string refreshToken)
        {
            return Ok(null);
        }


    }
}