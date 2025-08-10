namespace MarketPlace.Infrastructure.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public String Name { get; set; } = String.Empty;
    public String LastName { get; set; } = String.Empty;
    public String Email { get; set; }   = String.Empty;
    public String PhoneNumber { get; set; } = String.Empty;
    public String PasswordHash { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
}
