using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Application.Commands.Users;

public record AddUserCommand(
    String? Name,
    String? LastName,
    String? PhoneNumber,
    String? Email,
    String? Password
):IRequest<ActionResult<Guid?>>;
