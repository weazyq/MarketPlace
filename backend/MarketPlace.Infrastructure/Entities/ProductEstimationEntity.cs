namespace MarketPlace.Infrastructure.Entities;

public class ProductEstimationEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public float Estimation { get; set; }
    public DateTime CreatedAt { get; set; }

}
