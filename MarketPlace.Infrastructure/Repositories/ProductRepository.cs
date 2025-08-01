using MarketPlace.Domain.Catalogs.Product;
using MarketPlace.Domain.Interfaces;
using MarketPlace.Infrastructure.Data;
using MarketPlace.Infrastructure.Entities;
using MarketPlace.Domain.Events;

namespace MarketPlace.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _dbContext;

        public ProductRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken)
        {
            ProductEntity productToAdd = new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CreatedAt = product.CreatedAt,
            };

            productToAdd.AddEvent(new ProductAddedEvent(productToAdd.Id, productToAdd.Name, productToAdd.CreatedAt));

            await _dbContext.Products.AddAsync(productToAdd, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
