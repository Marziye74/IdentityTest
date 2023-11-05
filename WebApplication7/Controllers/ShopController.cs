using AplicationLayer.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;
        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("AddShop")]
        [Authorize]
        public async Task<IActionResult> AddShop([FromBody] AddShopCommandRequest command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPut("UpdateShop")]
        [Authorize]
        public async Task<IActionResult> UpdateShop([FromBody] UpdateShopCommandRequest command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));
        }

        [HttpDelete("DeleteShop")]
        [Authorize]
        public async Task<IActionResult> DeleteShop(DeleteShopCommandRequest command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
