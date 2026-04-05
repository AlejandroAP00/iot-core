using System;
using System.Collections.Generic;
using System.Text;
using Core.Application.Interfaces;
using Core.Domain.Entities;

namespace Core.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

    private static readonly List<User> _users = new List<User>
    {
        new User()
        {
          Id = Guid.NewGuid(),
          IsAdmin = false,
          IsVerified = false,
          Authentication = new Authentication()
          {
              Id =  Guid.NewGuid(),
              Email = "pepe@gmail.com",
              Password=  "Password",
              PhoneNumber= "9994932938",
              SecretKey= "fesfsefesf",
              UserId= Guid.NewGuid()
          },
          Profile= new Profile()
          {
              FirstName= "paco",
              LastName= "paco",
              Id = Guid.NewGuid(),
              Picture = "esfsf",
              UpdatedAt = DateTime.Now,
          }
        }
    };

    public Task<User?> Add(User user)
    {
        _users.Add(user);

        User? responseUser = _users.Find(x => x.Id == user.Id);

        return Task.FromResult(responseUser);
    }

    public Task<User?> GetUserById(Guid id)
    {
        var user = _users.First();

        return Task.FromResult(user);
    }
}
