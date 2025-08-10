using MarketPlace.Domain.Interfaces;
using MarketPlace.Domain.Shops;
using MediatR;

namespace MarketPlace.Application.Commands.Shops;

public class AddShopHandler : IRequestHandler<AddShopCommand, Guid>
{
    private readonly IShopRepository _shopRepository;

    public AddShopHandler(IShopRepository shopRepository)
    {
        _shopRepository = shopRepository;
    }

    public async Task<Guid> Handle(AddShopCommand request, CancellationToken cancellationToken)
    {
        Shop shop = new Shop(Guid.NewGuid(), request.Name, request.JuridicalName, request.Description);
        await _shopRepository.AddAsync(shop, cancellationToken);

        return shop.Id;
    }
}
