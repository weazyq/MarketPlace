using MarketPlace.API.Requests;
using MarketPlace.Application.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers;

public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator) 
    {
        mediator = _mediator;
    }

    [HttpPost("users/save")]
    public async Task<IActionResult> SaveUser([FromBody] AddUserRequest request)
    {
        AddUserCommand addUserCommand = new AddUserCommand(request.Name, request.LastName, request.PhoneNumber, request.Email, request.Password);
        ActionResult<Guid?> userId = await _mediator.Send(addUserCommand);
        return CreatedAtAction(nameof(GetById), new { id = userId }, null);
    }

    [HttpGet("users/{id}")]
    public IActionResult GetById(Guid id) => Ok();
}
