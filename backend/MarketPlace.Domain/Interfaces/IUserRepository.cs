using MarketPlace.Domain.Users;

namespace MarketPlace.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Boolean> AddAsync(User user);
    }
}
