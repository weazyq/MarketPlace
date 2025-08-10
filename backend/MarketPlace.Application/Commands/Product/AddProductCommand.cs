using MediatR;

namespace MarketPlace.Application.Commands.Product;

public record AddProductCommand(
    string Name,
    string Description
): IRequest<Guid>;