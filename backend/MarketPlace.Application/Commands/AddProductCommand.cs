using MediatR;

namespace MarketPlace.Application.Commands;

public record AddProductCommand(
    String Name,
    String Description
): IRequest<Guid>;