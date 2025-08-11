using MarketPlace.Domain.Catalogs.Products;
using MarketPlace.Domain.Interfaces;
using MarketPlace.Infrastructure.Entities;
using MarketPlace.Domain.Events;

namespace MarketPlace.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dbContext;

        public ProductRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken)
        {
            ProductEntity productToAdd = new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CreatedAt = product.CreatedAt,
            };
            productToAdd.AddEvent(new ProductAddedEvent(product.Id, product.Name, product.CreatedAt));

            await _dbContext.Products.AddAsync(productToAdd, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
