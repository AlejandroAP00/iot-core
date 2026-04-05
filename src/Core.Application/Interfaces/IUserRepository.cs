using System;
using Core.Domain.Entities;

namespace Core.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserById(Guid id);
    Task<User?> Add(User user); 

}
