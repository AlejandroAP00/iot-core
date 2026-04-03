using Core.Application.Interfaces;
using Core.Domain.Entities;

namespace Core.Application.Services;
public class UserService
 {
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }


    public async Task CreateUser( Guid id, bool isAdmin, bool isVerified, string firstName, string lastName, string picture)
    {
        var user = new User
        {
            Id = id,
            IsAdmin = isAdmin,
            IsVerified = isVerified,
            Profile = new Profile
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Picture = picture,
                UpdatedAt = DateTime.UtcNow
            }
        };
        await _repo.Add(user);
    }
}
