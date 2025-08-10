
using MediatR;

namespace MarketPlace.Application.Commands.Shops
{
    public record AddShopCommand
    (
        String Name,
        String JuridicalName,
        String Description
    ) : IRequest<Guid>;
}
