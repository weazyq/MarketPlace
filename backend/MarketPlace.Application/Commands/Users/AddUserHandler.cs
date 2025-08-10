using MarketPlace.Domain.Interfaces;
using MarketPlace.Domain.Users;
using MarketPlace.Infrastructure.Services.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Application.Commands.Users;

public class AddUserHandler : IRequestHandler<AddUserCommand, ActionResult<Guid?>>
{
    private readonly IUserRepository _userRepository;
    public AddUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ActionResult<Guid?>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Email) || String.IsNullOrWhiteSpace(request.PhoneNumber))
            return new BadRequestResult();
        if (String.IsNullOrWhiteSpace(request.Name) || String.IsNullOrWhiteSpace(request.LastName))
            return new BadRequestResult();
        if (String.IsNullOrWhiteSpace(request.Password))
            return new BadRequestResult();

        PasswordService passwordService = new PasswordService();
        String passwordHash = passwordService.HashPassword(request.Password);
        User user = new(Guid.NewGuid(), request.Name, request.LastName, request.Email, request.PhoneNumber, passwordHash);

        Boolean isUserSaved = await _userRepository.AddAsync(user);

        if (isUserSaved) return user.Id;
        else return new BadRequestResult();
    }
}
