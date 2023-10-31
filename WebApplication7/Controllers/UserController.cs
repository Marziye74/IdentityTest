using AplicationLayer.Request.Command;
using AplicationLayer.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("RegisterUser")]
        //[Authorize]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommandRequest command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpGet("LoginUser")]
        //[Authorize]
        public async Task<IActionResult> LoginUser(LoginUserQueryRequest query, CancellationToken cancellationToken)
        {
            var resault = await _mediator.Send(query, cancellationToken);

            return Ok(resault);
        }
    }
}
