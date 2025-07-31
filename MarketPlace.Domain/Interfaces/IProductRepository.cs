using MarketPlace.Domain.Catalogs.Product;

namespace MarketPlace.Domain.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken);
}
