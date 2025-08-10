using MarketPlace.Domain.Shops;

namespace MarketPlace.Domain.Interfaces;

public interface IShopRepository
{
    Task AddAsync(Shop shop, CancellationToken cancellationToken);
}
