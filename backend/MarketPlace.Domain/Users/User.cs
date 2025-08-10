namespace MarketPlace.Domain.Users;

public class User
{
    public Guid Id { get; }
    public String Name { get; }
    public String LastName { get; }
    public String Email { get; }
    public String PhoneNumber { get; }
    public String PasswordHash { get; }

    public User(Guid id, String name, String lastName, String email, String phoneNumber, String passwordHash)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
    }
}
