using AplicationLayer.Common;
using AplicationLayer.Interfaces;
using AplicationLayer.Request.Command;
using AplicationLayer.Request.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("GenerateTokenCommand")]
        //[AllowAnonymous]
        public IActionResult GenerateTokenCommand([FromBody] RegisterUserCommandRequest addUser, CancellationToken cancellationToken)
        {
            return Ok(_loginService.GenerateTokenCommand(addUser, cancellationToken));
        }

        [HttpPost("GenerateTokenQuery")]
        //[AllowAnonymous]
        public IActionResult GenerateTokenQuery([FromBody] LoginUserQueryRequest user, CancellationToken cancellationToken)
        {
            return Ok(_loginService.GenerateTokenQuery(user, cancellationToken));
        }
    }
}
