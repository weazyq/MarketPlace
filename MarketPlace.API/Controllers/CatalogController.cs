using MarketPlace.Domain.Catalogs.Product;
using MarketPlace.Web.Services.Catalog.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Web.Controllers;

[ApiController]
public class CatalogController : ControllerBase
{
    private readonly ICatalogService _catalogService;

    public CatalogController(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    [HttpPost("catalog/products")]
    public Product SaveProduct(ProductBlank productBlank)
    {
        return _catalogService.SaveProduct(productBlank);
    }
}
