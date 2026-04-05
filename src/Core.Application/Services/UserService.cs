using Core.Application.DTOs;
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


    public async Task<UserDto> CreateUser( Guid id, bool isAdmin, bool isVerified, string firstName, string lastName, string picture)
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
        User? response = await _repo.Add(user);

        if (response == null) throw new Exception("Failed to create user");

        return UserDto.fromEntity(response);
    }
}
