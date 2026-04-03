using System;
using System.Collections.Generic;
using System.Text;
using Core.Application.Interfaces;
using Core.Domain.Entities;

namespace Core.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

    private static readonly List<User> _users = new();

    public Task Add(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task<User?> GetUserById(Guid id)
    {
        var user = _users.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(user);
    }
}
