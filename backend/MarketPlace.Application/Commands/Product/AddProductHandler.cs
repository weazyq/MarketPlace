using MarketPlace.Domain.Catalogs.Product;
using MarketPlace.Domain.Interfaces;
using MediatR;

namespace MarketPlace.Application.Commands.Product;

public class AddProductHandler : IRequestHandler<AddProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;

    public AddProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        Product product = new Product(Guid.NewGuid(), request.Name, request.Description, DateTime.UtcNow, null);
        await _productRepository.AddAsync(product, cancellationToken);

        // Добавить Publish Event, Save EventStore

        return product.Id;
    }
}
