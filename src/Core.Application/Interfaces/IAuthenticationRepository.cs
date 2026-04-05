using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Interfaces;

public interface IAuthenticationRepository
{

    bool doesEmailExist(String email);

    bool login(String email, String password);

    public Task<Authentication?> GetAuthenticationByUserEmail(String email);
}
