using MediatR;

namespace MarketPlace.Application.Commands.Products;

public record AddProductCommand(
    string Name,
    string Description
): IRequest<Guid>;