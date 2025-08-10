using MarketPlace.Domain.Interfaces;
using MarketPlace.Domain.Shops;
using MarketPlace.Infrastructure.Entities;

namespace MarketPlace.Infrastructure.Persistence.Repositories;

public class ShopRepository : IShopRepository
{
    private readonly DataContext _dbContext;

    public ShopRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Shop shop, CancellationToken cancellationToken)
    {
        ShopEntity shopToAdd = new ShopEntity
        { 
            Id = shop.Id,
            Name = shop.Name,
            Description = shop.Description,
            JuridicalName = shop.JuridicalName,
            CreatedAt = DateTime.UtcNow
        };

        await _dbContext.Shops.AddAsync(shopToAdd, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
