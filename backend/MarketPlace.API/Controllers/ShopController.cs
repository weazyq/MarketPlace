using MarketPlace.API.Requests;
using MarketPlace.Application.Commands.Shops;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    public class ShopController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("shops/save")]
        public async Task<IActionResult> AddShop ([FromBody] AddShopRequest request)
        {
            AddShopCommand command = new AddShopCommand(request.Name, request.JuridicalName, request.Description);
            Guid shopId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = shopId }, null);
        }

        [HttpGet("shops/{id}")]
        public IActionResult GetById(Guid id) => Ok();
    }
}
