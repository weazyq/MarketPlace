namespace MarketPlace.API.Requests;

public record AddUserRequest(
    String? Name,
    String? LastName,
    String? PhoneNumber,
    String? Email,
    String? Password
);
