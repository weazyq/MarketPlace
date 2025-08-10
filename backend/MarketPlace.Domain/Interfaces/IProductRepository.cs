using MarketPlace.Domain.Catalogs.Products;

namespace MarketPlace.Domain.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken);
}
