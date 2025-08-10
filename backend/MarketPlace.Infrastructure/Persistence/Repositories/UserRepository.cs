using MarketPlace.Domain.Interfaces;
using MarketPlace.Domain.Users;
using MarketPlace.Infrastructure.Entities;
using Microsoft.Extensions.Logging;

namespace MarketPlace.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ILogger<IUserRepository> _logger;
    private readonly IUserRepository _userRepository;
    private readonly DataContext _dbContext;

    public UserRepository(
        ILogger<IUserRepository> logger,
        IUserRepository userRepository, 
        DataContext dbContext
    )
    {
        _logger = logger;
        _userRepository = userRepository;
        _dbContext = dbContext;
    }

    public async Task<Boolean> AddAsync(User user)
    {
        UserEntity userEntity = new UserEntity
        {
            Id = Guid.NewGuid(),
            Name = user.Name,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            PasswordHash = user.PasswordHash,
            CreatedAt = DateTime.UtcNow,
        };

        try
        {
            await _dbContext.Users.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"{0} | Can't save user {1}. {e.Message}", DateTime.UtcNow, $"{userEntity.Name + userEntity.LastName}");
        }

        return false;
    }
}
