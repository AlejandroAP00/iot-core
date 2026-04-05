using System;
using System.Collections.Generic;
using System.Text;

using Core.Application.Interfaces;
using Core.Domain.Entities;

namespace Core.Infrastructure.Repositories;

public class AuthenticationRepository : IAuthenticationRepository
{
    private static readonly List<Authentication> _authentications = new List<Authentication>()
    {
        new Authentication()
        {
            Id = Guid.NewGuid(),
            Email = "admin@acme.com",
            Password = "Password",
            PhoneNumber = "123456789",
            UserId = Guid.NewGuid()
       }
    };

    public bool doesEmailExist(string email)
    {
        throw new NotImplementedException();
    }

    public bool login(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<Authentication?> GetAuthenticationByUserEmail(String email)
    {
        Authentication? auth = _authentications.First();
        return Task.FromResult(auth);
    }
}
