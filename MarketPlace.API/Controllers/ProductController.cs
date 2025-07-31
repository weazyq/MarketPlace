using MarketPlace.API.Requests;
using MarketPlace.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers;

public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("products/save")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
    {
        AddProductCommand command = new AddProductCommand(request.Name, request.Description);

        Guid productId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = productId }, null);
    }

    [HttpGet("products/{id}")]
    public IActionResult GetById(Guid id) => Ok();
}
