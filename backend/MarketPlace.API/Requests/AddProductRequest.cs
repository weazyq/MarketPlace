namespace MarketPlace.API.Requests;

public class AddProductRequest
{
    public required String Name { get; set; }
    public required String Description { get; set; }
    public required Decimal Price { get; set; }
    public required Guid ShopId { get; set; }
}
